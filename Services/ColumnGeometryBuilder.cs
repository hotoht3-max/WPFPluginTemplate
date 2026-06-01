using System;
using System.Collections.Generic;
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

            Point p1Start = new Point(data.BasePoint1);
            p1Start.Translate(upVector * -data.Hcol_e1);
            Point p1End = new Point(data.BasePoint1);
            p1End.Translate(upVector * data.Hcol_1);
            lines.Add(new LineSegment(p1Start, p1End));

            Point p2Start = new Point(data.BasePoint2);
            p2Start.Translate(upVector * -data.Hcol_e1);
            Point p2End = new Point(data.BasePoint2);
            p2End.Translate(upVector * data.Hcol_1);
            lines.Add(new LineSegment(p2Start, p2End));

            return lines;
        }

        public static List<LineSegment> GetLacingLines(BuiltUpColumnData data)
        {
            List<LineSegment> lines = new List<LineSegment>();

            double zoneLength = (data.Hcol_1 + data.Hcol_e1) - data.Hcol_e2 - data.Hcol_e3;
            if (zoneLength <= 0 || data.Hr_base <= 0) return lines;

            int panelsCount = (int)Math.Round(zoneLength / data.Hr_base);
            if (panelsCount < 1) panelsCount = 1;

            double actualStep = zoneLength / panelsCount;
            Vector upVector = VectorExtension.Z;

            Point startLeft = new Point(data.BasePoint1);
            startLeft.Translate(upVector * (-data.Hcol_e1 + data.Hcol_e2));

            Point startRight = new Point(data.BasePoint2);
            startRight.Translate(upVector * (-data.Hcol_e1 + data.Hcol_e2));

            bool toggleToRight = true;
            Point currentCenter = startLeft;

            for (int i = 1; i <= panelsCount; i++)
            {
                Point nextCenter = toggleToRight ? new Point(startRight) : new Point(startLeft);
                nextCenter.Translate(upVector * (actualStep * i));

                Point pStart = new Point(currentCenter);
                Point pEnd = new Point(nextCenter);

                // Применяем расцентровку ко всем внутренним узлам
                if (i > 1)
                {
                    pStart.Translate(upVector * data.L_Rasc);
                }
                if (i < panelsCount)
                {
                    pEnd.Translate(upVector * -data.L_Rasc);
                }

                if (toggleToRight)
                {
                    lines.Add(new LineSegment(pStart, pEnd));
                }
                else
                {
                    // Меняем точки местами, чтобы вектор всегда шел Слева-Направо
                    lines.Add(new LineSegment(pEnd, pStart));
                }

                currentCenter = nextCenter;
                toggleToRight = !toggleToRight;
            }

            return lines;
        }

        public static List<LineSegment> GetStrutLines(BuiltUpColumnData data)
        {
            List<LineSegment> lines = new List<LineSegment>();

            double zoneLength = (data.Hcol_1 + data.Hcol_e1) - data.Hcol_e2 - data.Hcol_e3;
            if (zoneLength <= 0 || data.Hr_base <= 0) return lines;

            int panelsCount = (int)Math.Round(zoneLength / data.Hr_base);
            if (panelsCount < 1) panelsCount = 1;

            double actualStep = zoneLength / panelsCount;
            Vector upVector = VectorExtension.Z;

            Point startLeft = new Point(data.BasePoint1);
            startLeft.Translate(upVector * (-data.Hcol_e1 + data.Hcol_e2));

            Point startRight = new Point(data.BasePoint2);
            startRight.Translate(upVector * (-data.Hcol_e1 + data.Hcol_e2));

            // Планки генерируются на каждом шаге (от 0 до panelsCount включительно)
            for (int i = 0; i <= panelsCount; i++)
            {
                Point p1 = new Point(startLeft);
                p1.Translate(upVector * (actualStep * i));

                Point p2 = new Point(startRight);
                p2.Translate(upVector * (actualStep * i));

                lines.Add(new LineSegment(p1, p2));
            }

            return lines;
        }
    }
}