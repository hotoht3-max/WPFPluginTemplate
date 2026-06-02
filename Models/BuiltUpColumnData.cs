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

        public string SplicesText { get; set; }  // Отметки стыков ветвей

        public int L_StepMode { get; set; }
        public double Hr_base { get; set; }
        public string L_StepText { get; set; }

        public double L_Rasc { get; set; }
        public double L_Rasc_Base { get; set; }  // Расцентровка для базы
        public double L_Rasc_Top { get; set; }   // Расцентровка для верха
        public string L_RascOverrides { get; set; } // Исключения (Узел:Вверх/Вниз)

        public int L_Type { get; set; }
        public int L_Preset { get; set; }
        public double L_Offset { get; set; }

        public int S_Mode { get; set; }
        public string S_NodesDouble { get; set; }
        public string S_NodesChannel { get; set; }
        public string S_NodesExclude { get; set; }

        public int S_Base_Preset { get; set; }   // Планка в базе
        public int S_Top_Preset { get; set; }    // Планка в верхушке
        public int S_Splice_Preset { get; set; } // Планки вокруг стыков
        public int S_Preset { get; set; }        // Рядовые планки

        // Профили и материалы
        public string BranchProfile { get; set; }
        public string LacingProfile { get; set; }
        public string S_Profile { get; set; }
        public string D_Profile { get; set; }

        public string Material { get; set; }
        public string S_Material { get; set; }
        public string D_Material { get; set; }
    }
}