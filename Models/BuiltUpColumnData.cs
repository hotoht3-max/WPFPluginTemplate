using System.Collections.Generic;

namespace Apibim.Plugins.BuiltUpColumn.Models
{
    public class BuiltUpColumnData
    {
        // Геометрия
        public double Bcol { get; set; }
        public double Br_Rot { get; set; }
        public double Hcol_1 { get; set; }
        public double Hcol_e1 { get; set; }
        public double Hcol_e2 { get; set; }
        public double Hcol_e3 { get; set; }

        // Стыки ветвей
        public string SplicesText { get; set; }
        public string Splice1Component { get; set; }
        public string Splice1Preset { get; set; }
        public string Splice2Component { get; set; }
        public string Splice2Preset { get; set; }
        public string Splice2Indexes { get; set; }
        public string Splice3Component { get; set; }
        public string Splice3Preset { get; set; }
        public string Splice3Indexes { get; set; }
        public string Splice4Component { get; set; }
        public string Splice4Preset { get; set; }
        public string Splice4Indexes { get; set; }
        public string Splice5Component { get; set; }
        public string Splice5Preset { get; set; }
        public string Splice5Indexes { get; set; }

        // Решетка
        public int L_StepMode { get; set; }
        public string L_StepText { get; set; }
        public double L_Rasc { get; set; }
        public double L_Rasc_Base { get; set; }
        public double L_Rasc_Top { get; set; }
        public string L_RascOverrides { get; set; }
        public int L_Type { get; set; }
        public int L_Preset { get; set; }
        public double L_Offset { get; set; }

        // --- НОВЫЕ СВОЙСТВА ALPHA 1.2 ---
        public int L_Invert { get; set; }
        public string L_Exclude { get; set; }
        public double L_MinRemainder { get; set; }
        public int L_RemainPanels { get; set; }
        public int L_MergePanels { get; set; }
        public int L_HoldPhase { get; set; }

        // Планки
        public int S_Base_Preset { get; set; }
        public int S_Top_Preset { get; set; }
        public int S_Splice_Preset { get; set; }
        public int S_Preset { get; set; }
        public int S_KeyElev_Preset { get; set; } // <--- Ключевые отметки
        public string S_NodesAngle { get; set; }
        public string S_NodesAnglePlate { get; set; }
        public string S_NodesD1 { get; set; }
        public string S_NodesD2 { get; set; }
        public string S_NodesExcludePlate { get; set; }
        public string S_NodesExclude { get; set; }

        // Детали
        public PartSettings Branch { get; set; }
        public PartSettings Diaphragm1 { get; set; }
        public PartSettings Diaphragm2 { get; set; }
        public PartSettings Lacing { get; set; }
        public PartSettings LacingSplice { get; set; }
        public PartSettings Strut { get; set; }
        public PartSettings GussetPlate { get; set; }

        // Базовые точки (вычисляются в плагине)
        public Tekla.Structures.Geometry3d.Point BasePoint1 { get; set; }
        public Tekla.Structures.Geometry3d.Point BasePoint2 { get; set; }
    }
}