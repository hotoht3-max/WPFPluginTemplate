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

        // --- КАСКАДНЫЕ СТЫКИ (5 УРОВНЕЙ) ---
        public string SplicesText { get; set; } // Отметки стыков в модели (Z)

        public string Splice1Component { get; set; }
        public string Splice1Preset { get; set; } // Уровень 1 (Базовый)
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

        public int L_StepMode { get; set; }
        public double Hr_base { get; set; }
        public string L_StepText { get; set; }
        public double L_Rasc { get; set; }
        public double L_Rasc_Base { get; set; }
        public double L_Rasc_Top { get; set; }
        public string L_RascOverrides { get; set; }
        public int L_Type { get; set; }
        public int L_Preset { get; set; }
        public double L_Offset { get; set; }

        public int S_Mode { get; set; }
        public string S_NodesDouble { get; set; }
        public string S_NodesChannel { get; set; }
        public string S_NodesExclude { get; set; }
        public int S_Base_Preset { get; set; }
        public int S_Top_Preset { get; set; }
        public int S_Splice_Preset { get; set; }
        public int S_Preset { get; set; }

        // --- МАТРИЦА АТРИБУТОВ ---
        public string B_Profile { get; set; }
        public string B_Material { get; set; }
        public string B_AssyPref { get; set; }
        public string B_AssyNo { get; set; }
        public string B_PartPref { get; set; }
        public string B_PartNo { get; set; }
        public string B_Name { get; set; }
        public string B_Class { get; set; }
        public string B_UDA { get; set; }
        public string D_Profile { get; set; }
        public string D_Material { get; set; }
        public string D_AssyPref { get; set; }
        public string D_AssyNo { get; set; }
        public string D_PartPref { get; set; }
        public string D_PartNo { get; set; }
        public string D_Name { get; set; }
        public string D_Class { get; set; }
        public string D_UDA { get; set; }
        public string L_Profile { get; set; }
        public string L_Material { get; set; }
        public string L_AssyPref { get; set; }
        public string L_AssyNo { get; set; }
        public string L_PartPref { get; set; }
        public string L_PartNo { get; set; }
        public string L_Name { get; set; }
        public string L_Class { get; set; }
        public string L_UDA { get; set; }
        public string LS_Profile { get; set; }
        public string LS_Material { get; set; }
        public string LS_AssyPref { get; set; }
        public string LS_AssyNo { get; set; }
        public string LS_PartPref { get; set; }
        public string LS_PartNo { get; set; }
        public string LS_Name { get; set; }
        public string LS_Class { get; set; }
        public string LS_UDA { get; set; }
        public string S_Profile { get; set; }
        public string S_Material { get; set; }
        public string S_AssyPref { get; set; }
        public string S_AssyNo { get; set; }
        public string S_PartPref { get; set; }
        public string S_PartNo { get; set; }
        public string S_Name { get; set; }
        public string S_Class { get; set; }
        public string S_UDA { get; set; }
    }
}