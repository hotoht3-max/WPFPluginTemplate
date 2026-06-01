using System;
using Tekla.Structures.Geometry3d;

namespace Apibim.Plugins.BuiltUpColumn.Models
{
    public class BuiltUpColumnData
    {
        public Point BasePoint1 { get; set; }
        public Point BasePoint2 { get; set; }

        public double Bcol { get; set; }
        public double Br_Rot { get; set; }
        public double Hcol_1 { get; set; }
        public double Hcol_e1 { get; set; }
        public double Hcol_e2 { get; set; }
        public double Hcol_e3 { get; set; }

        public double Hr_base { get; set; }
        public double L_Rasc { get; set; }
        public int L_Type { get; set; }
        public int L_Preset { get; set; }
        public double L_Offset { get; set; }

        // Планки
        public int S_Preset { get; set; } // 0=Нет, 1=Как решетка, 2=Швеллер

        public string BranchProfile { get; set; }
        public string LacingProfile { get; set; }
        public string S_Profile { get; set; }

        public string Material { get; set; }
        public string S_Material { get; set; }
    }
}