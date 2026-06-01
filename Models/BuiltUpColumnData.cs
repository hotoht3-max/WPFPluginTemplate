using System;
using Tekla.Structures.Geometry3d;

namespace Apibim.Plugins.BuiltUpColumn.Models
{
    public class BuiltUpColumnData
    {
        public Point BasePoint1 { get; set; }
        public Point BasePoint2 { get; set; }

        public double Hcol_1 { get; set; }
        public double Hcol_e1 { get; set; }
        public double Hcol_e2 { get; set; }
        public double Hcol_e3 { get; set; }
        public double Hr_base { get; set; }

        public string BranchProfile { get; set; } = "I20K1_57837_2017";
        public string LacingProfile { get; set; } = "L75X6_8509_93";
        public string Material { get; set; } = "C245";
    }
}