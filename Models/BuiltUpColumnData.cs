using System.Collections.Generic;
using Tekla.Structures.Plugins;

namespace Apibim.Plugins.BuiltUpColumn.Models
{
    public class BuiltUpColumnData
    {
        // --- ALPHA 1.0: Геометрия ---
        public double Bcol { get; set; }
        public double Br_Rot { get; set; }
        public double Hcol_1 { get; set; }
        public double Hcol_e1 { get; set; }
        public double Hcol_e2 { get; set; }
        public double Hcol_e3 { get; set; }

        // --- ALPHA 1.1: Стыки ветвей ---
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

        // --- ALPHA 1.2: Решетка и Планки ---
        public int L_StepMode { get; set; }
        public string L_StepText { get; set; }
        public double L_MinRemainder { get; set; }
        public int L_MergePanels { get; set; }
        public int L_RemainPanels { get; set; }

        public int L_Invert { get; set; }
        public string L_Exclude { get; set; }
        public int L_HoldPhase { get; set; }

        public double L_Rasc { get; set; }
        public double L_Rasc_Base { get; set; }
        public double L_Rasc_Top { get; set; }
        public string L_RascOverrides { get; set; }

        public int L_Type { get; set; }
        public int L_Preset { get; set; }
        public double L_Offset { get; set; }

        public int S_Base_Preset { get; set; }
        public int S_Top_Preset { get; set; }
        public int S_Splice_Preset { get; set; }
        public int S_KeyElev_Preset { get; set; }
        public int S_Preset { get; set; }
        public string S_NodesAngle { get; set; }
        public string S_NodesAnglePlate { get; set; }
        public string S_NodesD1 { get; set; }
        public string S_NodesD2 { get; set; }
        public string S_NodesExcludePlate { get; set; }
        public string S_NodesExclude { get; set; }

        // --- ALPHA 1.3: Врезка и Позиционирование диафрагм ---
        public string D1_CutComp { get; set; }
        public string D1_CutAttr { get; set; }
        public string D2_CutComp { get; set; }
        public string D2_CutAttr { get; set; }
        public int GP_CutMode { get; set; }
        public int D1_CutMode { get; set; }
        public int D2_CutMode { get; set; }
        public double D_GapW { get; set; }
        public double D_GapL { get; set; }

        public int D1_PosPlane { get; set; }
        public double D1_PosPlaneOff { get; set; }
        public int D1_PosRot { get; set; }
        public double D1_PosRotOff { get; set; }
        public int D1_PosDepth { get; set; }
        public double D1_PosDepthOff { get; set; }

        public int D2_PosPlane { get; set; }
        public double D2_PosPlaneOff { get; set; }
        public int D2_PosRot { get; set; }
        public double D2_PosRotOff { get; set; }
        public int D2_PosDepth { get; set; }
        public double D2_PosDepthOff { get; set; }

        // --- ДЕТАЛИ ---
        public PartSettings Branch { get; set; }
        public PartSettings Diaphragm1 { get; set; }
        public PartSettings Diaphragm2 { get; set; }
        public PartSettings Lacing { get; set; }
        public PartSettings LacingSplice { get; set; }
        public PartSettings Strut { get; set; }
        public PartSettings GussetPlate { get; set; }

        // --- БАЗОВЫЕ ТОЧКИ ---
        public Tekla.Structures.Geometry3d.Point BasePoint1 { get; set; }
        public Tekla.Structures.Geometry3d.Point BasePoint2 { get; set; }

        // --- ALPHA 1.4: НАДКОЛОННИК ---
        public int NK_Mode { get; set; }
        public int NK_HeightType { get; set; }
        public double NK_Value { get; set; }
        public double NK_Offset { get; set; }
        public double NK_Rot { get; set; }
        public PartSettings SupColumn { get; set; }

		// --- ALPHA 1.6.1: СМЕЩЕНИЯ ---
		public double Global_Dx { get; set; }
		public double Global_Dy { get; set; }
		public double Global_Rot { get; set; }

	}
}