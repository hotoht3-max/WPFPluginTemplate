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

            Point p1Start = new Point(data.BasePoint1);
            p1Start.Translate(VectorExtension.Z * -data.Hcol_e1);
            Point p1End = new Point(data.BasePoint1);
            p1End.Translate(VectorExtension.Z * data.Hcol_1);
            lines.Add(new LineSegment(p1Start, p1End));

            Point p2Start = new Point(data.BasePoint2);
            p2Start.Translate(VectorExtension.Z * -data.Hcol_e1);
            Point p2End = new Point(data.BasePoint2);
            p2End.Translate(VectorExtension.Z * data.Hcol_1);
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

            Point startLeft = new Point(data.BasePoint1);
            startLeft.Translate(VectorExtension.Z * (-data.Hcol_e1 + data.Hcol_e2));

            Point startRight = new Point(data.BasePoint2);
            startRight.Translate(VectorExtension.Z * (-data.Hcol_e1 + data.Hcol_e2));

            bool toggleToRight = true;
            Point currentPoint = startLeft;

            for (int i = 1; i <= panelsCount; i++)
            {
                Point nextPoint = toggleToRight ? new Point(startRight) : new Point(startLeft);
                nextPoint.Translate(VectorExtension.Z * (actualStep * i));

                lines.Add(new LineSegment(currentPoint, nextPoint));

                currentPoint = nextPoint;
                toggleToRight = !toggleToRight;
            }

            return lines;
        }
    }
}