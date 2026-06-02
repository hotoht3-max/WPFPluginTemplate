using System;
using System.Collections.Generic;
using System.Linq;
using Tekla.Structures.Geometry3d;
using Apibim.Plugins.BuiltUpColumn.Models;
using Tekla.Extension;

namespace Apibim.Plugins.BuiltUpColumn.Services
{
    public static class ColumnGeometryBuilder
    {
        // 1. РАЗБИВКА ВЕТВЕЙ СО СТЫКАМИ
        public static List<LineSegment> GetBranchLines(BuiltUpColumnData data)
        {
            List<LineSegment> lines = new List<LineSegment>();
            Vector upVector = VectorExtension.Z;

            double startZ = -data.Hcol_e1;
            double endZ = data.Hcol_1;

            // Читаем стыки, фильтруем те, что вышли за габариты колонны (допуск 10мм)
            List<double> splices = StringParserService.ParseSplices(data.SplicesText)
                .Where(s => s > startZ + 10.0 && s < endZ - 10.0)
                .OrderBy(s => s).ToList();

            List<double> zPoints = new List<double> { startZ };
            zPoints.AddRange(splices);
            zPoints.Add(endZ);

            // Ветвь 1
            for (int i = 0; i < zPoints.Count - 1; i++)
            {
                Point pStart = new Point(data.BasePoint1); pStart.Translate(upVector * zPoints[i]);
                Point pEnd = new Point(data.BasePoint1); pEnd.Translate(upVector * zPoints[i + 1]);
                lines.Add(new LineSegment(pStart, pEnd));
            }

            // Ветвь 2
            for (int i = 0; i < zPoints.Count - 1; i++)
            {
                Point pStart = new Point(data.BasePoint2); pStart.Translate(upVector * zPoints[i]);
                Point pEnd = new Point(data.BasePoint2); pEnd.Translate(upVector * zPoints[i + 1]);
                lines.Add(new LineSegment(pStart, pEnd));
            }

            return lines;
        }

        // 2. АБСОЛЮТНЫЕ Z-ОТМЕТКИ УЗЛОВ
        public static List<double> GetZNodes(BuiltUpColumnData data)
        {
            double startZ = -data.Hcol_e1 + data.Hcol_e2;
            double endZ = data.Hcol_1 - data.Hcol_e3;
            double zoneLength = endZ - startZ;

            List<double> zNodes = new List<double> { startZ };
            if (zoneLength <= 0) return zNodes;

            List<double> finalSteps = new List<double>();

            if (data.L_StepMode == 0)
            {
                if (data.Hr_base > 0)
                {
                    int panelsCount = (int)Math.Round(zoneLength / data.Hr_base);
                    if (panelsCount < 1) panelsCount = 1;
                    double step = zoneLength / panelsCount;
                    for (int i = 0; i < panelsCount; i++) finalSteps.Add(step);
                }
            }
            else if (data.L_StepMode == 1)
            {
                var parsedSteps = StringParserService.ParseManualStep(data.L_StepText);
                if (parsedSteps.Count == 0) parsedSteps.Add(1200.0);

                double sum = 0;
                int i = 0;
                while (sum < zoneLength - 0.1)
                {
                    double s = i < parsedSteps.Count ? parsedSteps[i] : parsedSteps.Last();
                    double remain = zoneLength - sum;

                    if (remain - s > 0.1 && remain - s < data.Bcol)
                    {
                        double p1 = Math.Round((remain / 2.0) / 10.0) * 10.0;
                        finalSteps.Add(p1);
                        finalSteps.Add(remain - p1);
                        break;
                    }
                    if (remain <= s + 0.1)
                    {
                        finalSteps.Add(remain);
                        break;
                    }
                    finalSteps.Add(s);
                    sum += s;
                    i++;
                }
            }
            else if (data.L_StepMode == 2)
            {
                finalSteps = StringParserService.ParseCountAndElevation(data.L_StepText, startZ, endZ);
                double sum = 0;
                foreach (var s in finalSteps) sum += s;
                if (zoneLength - sum > 1.0) finalSteps.Add(zoneLength - sum);
            }

            double currentZ = startZ;
            foreach (var step in finalSteps)
            {
                currentZ += step;
                zNodes.Add(currentZ);
            }

            return zNodes;
        }

        // 3. ГЕНЕРАЦИЯ РАСКОСОВ С УМНОЙ РАСЦЕНТРОВКОЙ
        public static List<LineSegment> GetLacingLines(BuiltUpColumnData data, List<double> zNodes)
        {
            List<LineSegment> lines = new List<LineSegment>();
            if (zNodes.Count < 2) return lines;

            Vector upVector = VectorExtension.Z;
            var overrides = StringParserService.ParseRascOverrides(data.L_RascOverrides, zNodes.Count);

            bool toggleToRight = true;
            for (int i = 0; i < zNodes.Count - 1; i++)
            {
                Point currentLeft = new Point(data.BasePoint1); currentLeft.Translate(upVector * zNodes[i]);
                Point currentRight = new Point(data.BasePoint2); currentRight.Translate(upVector * zNodes[i]);

                Point nextLeft = new Point(data.BasePoint1); nextLeft.Translate(upVector * zNodes[i + 1]);
                Point nextRight = new Point(data.BasePoint2); nextRight.Translate(upVector * zNodes[i + 1]);

                Point currentCenter = toggleToRight ? currentLeft : currentRight;
                Point nextCenter = toggleToRight ? nextRight : nextLeft;

                Point pStart = new Point(currentCenter);
                Point pEnd = new Point(nextCenter);

                // Читаем сдвиги для старта (вектор уходит ВВЕРХ) и для конца (вектор приходит СНИЗУ)
                double shiftUp = GetRascUp(i, data, overrides, zNodes.Count);
                double shiftDown = GetRascDown(i + 1, data, overrides, zNodes.Count);

                // Применяем сдвиги
                pStart.Translate(upVector * shiftUp);
                pEnd.Translate(upVector * -shiftDown); // Минус, потому что сдвиг вниз от теор. узла

                if (toggleToRight) lines.Add(new LineSegment(pStart, pEnd));
                else lines.Add(new LineSegment(pEnd, pStart));

                toggleToRight = !toggleToRight;
            }

            return lines;
        }

        private static double GetRascUp(int nodeIndex, BuiltUpColumnData data, Dictionary<int, (double Up, double Down)> overrides, int maxNodes)
        {
            if (overrides.ContainsKey(nodeIndex)) return overrides[nodeIndex].Up;
            if (nodeIndex == 0) return data.L_Rasc_Base;
            return data.L_Rasc;
        }

        private static double GetRascDown(int nodeIndex, BuiltUpColumnData data, Dictionary<int, (double Up, double Down)> overrides, int maxNodes)
        {
            if (overrides.ContainsKey(nodeIndex)) return overrides[nodeIndex].Down;
            if (nodeIndex == maxNodes - 1) return data.L_Rasc_Top;
            return data.L_Rasc;
        }

        // 4. ТЕОРЕТИЧЕСКИЕ ОСИ ПЛАНОК
        public static List<LineSegment> GetStrutLines(BuiltUpColumnData data, List<double> zNodes)
        {
            List<LineSegment> lines = new List<LineSegment>();
            Vector upVector = VectorExtension.Z;

            for (int i = 0; i < zNodes.Count; i++)
            {
                Point p1 = new Point(data.BasePoint1); p1.Translate(upVector * zNodes[i]);
                Point p2 = new Point(data.BasePoint2); p2.Translate(upVector * zNodes[i]);
                lines.Add(new LineSegment(p1, p2));
            }

            return lines;
        }

        // 5. ПОИСК УЗЛОВ ВОКРУГ СТЫКА
        public static HashSet<int> GetSpliceAdjacentNodes(List<double> zNodes, List<double> splices)
        {
            var result = new HashSet<int>();
            foreach (var splice in splices)
            {
                int idxBelow = -1;
                int idxAbove = -1;
                double minDiffBelow = double.MaxValue;
                double minDiffAbove = double.MaxValue;

                for (int i = 0; i < zNodes.Count; i++)
                {
                    double diff = zNodes[i] - splice;
                    // Ищем ближайший снизу
                    if (diff < -0.1 && Math.Abs(diff) < minDiffBelow) { minDiffBelow = Math.Abs(diff); idxBelow = i; }
                    // Ищем ближайший сверху
                    if (diff > 0.1 && Math.Abs(diff) < minDiffAbove) { minDiffAbove = Math.Abs(diff); idxAbove = i; }
                }

                if (idxBelow != -1) result.Add(idxBelow);
                if (idxAbove != -1) result.Add(idxAbove);
            }
            return result;
        }
    }
}