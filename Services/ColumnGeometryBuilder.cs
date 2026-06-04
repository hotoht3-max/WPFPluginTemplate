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
        public static List<LineSegment> GetBranchLines(BuiltUpColumnData data)
        {
            List<LineSegment> lines = new List<LineSegment>();
            Vector upVector = VectorExtension.Z;

            double startZ = -data.Hcol_e1;
            double endZ = data.Hcol_1;

            List<double> splices = StringParserService.ParseSplices(data.SplicesText)
                .Where(s => s > startZ && s < endZ)
                .OrderBy(s => s).ToList();

            List<double> zPoints = new List<double> { startZ };
            zPoints.AddRange(splices);
            zPoints.Add(endZ);

            for (int i = 0; i < zPoints.Count - 1; i++)
            {
                Point pStart = new Point(data.BasePoint1); pStart.Translate(upVector * zPoints[i]);
                Point pEnd = new Point(data.BasePoint1); pEnd.Translate(upVector * zPoints[i + 1]);
                lines.Add(new LineSegment(pStart, pEnd));
            }
            for (int i = 0; i < zPoints.Count - 1; i++)
            {
                Point pStart = new Point(data.BasePoint2); pStart.Translate(upVector * zPoints[i]);
                Point pEnd = new Point(data.BasePoint2); pEnd.Translate(upVector * zPoints[i + 1]);
                lines.Add(new LineSegment(pStart, pEnd));
            }
            return lines;
        }

        public static List<double> GetZNodes(BuiltUpColumnData data)
        {
            double startZ = -data.Hcol_e1 + data.Hcol_e2;
            double endZ = data.Hcol_1 - data.Hcol_e3;
            double zoneLength = endZ - startZ;

            List<double> zNodes = new List<double> { startZ };
            if (zoneLength <= 0) return zNodes;

            List<double> finalSteps = new List<double>();
            var tokens = data.L_StepText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (data.L_StepMode == 0) // 0: РАВНОМЕРНЫЙ (Шаг - Отметка)
            {
                double currentZ = startZ;
                int i = 0;
                double lastStep = 1200; // Резервный шаг на случай ошибки

                while (currentZ < endZ - 0.1)
                {
                    double step = lastStep;
                    double targetZ = endZ;

                    if (i < tokens.Length)
                    {
                        if (double.TryParse(tokens[i], out double parsedStep) && parsedStep > 0)
                        {
                            step = parsedStep;
                            lastStep = step;
                            i++;

                            if (i < tokens.Length && double.TryParse(tokens[i], out double elev))
                            {
                                targetZ = Math.Min(elev, endZ);
                                i++;
                            }
                        }
                        else i++;
                    }

                    double len = targetZ - currentZ;
                    if (len > 0)
                    {
                        int panels = (int)Math.Round(len / step);
                        if (panels < 1) panels = 1;
                        double actualStep = Math.Round((len / panels) / 10.0) * 10.0;
                        if (actualStep <= 0) actualStep = 10.0;

                        double sum = 0;
                        for (int p = 0; p < panels - 1; p++)
                        {
                            finalSteps.Add(actualStep);
                            sum += actualStep;
                        }
                        finalSteps.Add(len - sum); // Хвост абсорбируется верхней панелью зоны
                        currentZ = targetZ;
                    }
                    else break;
                }
            }
            else if (data.L_StepMode == 1) // 1: МАССИВ (с возвратом старой логики)
            {
                var parsedSteps = StringParserService.ParseManualStep(data.L_StepText);
                if (parsedSteps.Count == 0) parsedSteps.Add(1200.0);

                double sum = 0;
                int i = 0;
                double minRem = data.L_MinRemainder > 0 ? data.L_MinRemainder : data.Bcol;
                int remPanels = data.L_RemainPanels > 0 ? data.L_RemainPanels : 2;

                while (sum < zoneLength - 0.1)
                {
                    double s = i < parsedSteps.Count ? parsedSteps[i] : parsedSteps.Last();
                    double remain = zoneLength - sum;

                    // Умный остаток срабатывает, если хвост меньше ограничения
                    if (remain - s > 0.1 && remain - s < minRem)
                    {
                        double actualStep = Math.Round((remain / remPanels) / 10.0) * 10.0;
                        if (actualStep <= 0) actualStep = 10.0;

                        double tempSum = 0;
                        for (int p = 0; p < remPanels - 1; p++)
                        {
                            finalSteps.Add(actualStep);
                            tempSum += actualStep;
                        }
                        finalSteps.Add(remain - tempSum);
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
            else if (data.L_StepMode == 2) // 2: КОЛ-ВО ПАНЕЛЕЙ И ОТМЕТКИ
            {
                double currentZ = startZ;
                int i = 0;
                int lastCount = 1;

                while (currentZ < endZ - 0.1)
                {
                    int count = lastCount;
                    double targetZ = endZ;

                    if (i < tokens.Length)
                    {
                        if (int.TryParse(tokens[i], out int parsedCount) && parsedCount > 0)
                        {
                            count = parsedCount;
                            i++;

                            if (i < tokens.Length && double.TryParse(tokens[i], out double elev))
                            {
                                targetZ = Math.Min(elev, endZ);
                                i++;
                            }
                        }
                        else i++;
                    }
                    else count = 1; // Если отметки закончились, оставшаяся часть - 1 панель

                    double len = targetZ - currentZ;
                    if (len > 0)
                    {
                        double actualStep = Math.Round((len / count) / 10.0) * 10.0;
                        if (actualStep <= 0) actualStep = 10.0;

                        double sum = 0;
                        for (int p = 0; p < count - 1; p++)
                        {
                            finalSteps.Add(actualStep);
                            sum += actualStep;
                        }
                        finalSteps.Add(len - sum);
                        currentZ = targetZ;
                    }
                    else break;
                }
            }

            double currentZNode = startZ;
            foreach (var step in finalSteps)
            {
                currentZNode += step;
                zNodes.Add(currentZNode);
            }

            return zNodes;
        }

        public static List<LineSegment> GetLacingLines(BuiltUpColumnData data, List<double> zNodes)
        {
            List<LineSegment> lines = new List<LineSegment>();
            if (zNodes.Count < 2) return lines;

            Vector upVector = VectorExtension.Z;
            var overrides = StringParserService.ParseRascOverrides(data.L_RascOverrides, zNodes.Count);

            // ИНВЕРСИЯ (Абсолютно изолированная логика)
            bool toggleToRight = data.L_Invert == 0;

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

                double shiftUp = GetRascUp(i, data, overrides, zNodes.Count);
                double shiftDown = GetRascDown(i + 1, data, overrides, zNodes.Count);

                pStart.Translate(upVector * shiftUp);
                pEnd.Translate(upVector * -shiftDown);

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
                    if (diff < -0.1 && Math.Abs(diff) < minDiffBelow) { minDiffBelow = Math.Abs(diff); idxBelow = i; }
                    if (diff > 0.1 && Math.Abs(diff) < minDiffAbove) { minDiffAbove = Math.Abs(diff); idxAbove = i; }
                }

                if (idxBelow != -1) result.Add(idxBelow);
                if (idxAbove != -1) result.Add(idxAbove);
            }
            return result;
        }

        // ПОИСК КЛЮЧЕВЫХ УЗЛОВ (С ювелирной точностью)
        public static HashSet<int> GetKeyElevationNodes(BuiltUpColumnData data, List<double> zNodes)
        {
            var result = new HashSet<int>();
            if (data.L_StepMode == 1) return result; // В Режиме 1 ключевых отметок нет

            var tokens = data.L_StepText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var keys = new HashSet<double>();

            int i = 0;
            while (i < tokens.Length)
            {
                i++; // Пропускаем шаг или кол-во
                if (i < tokens.Length && double.TryParse(tokens[i], out double elev))
                {
                    keys.Add(elev);
                    i++;
                }
            }

            // Ищем совпадения. Благодаря абсорбции остатка в верхних панелях, узлы будут стоять точно на отметках
            for (int j = 0; j < zNodes.Count; j++)
            {
                foreach (var key in keys)
                {
                    if (Math.Abs(zNodes[j] - key) < 1.0) result.Add(j);
                }
            }
            return result;
        }
    }
}