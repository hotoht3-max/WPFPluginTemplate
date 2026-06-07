using Apibim.Plugins.BuiltUpColumn.Models;

namespace Apibim.Plugins.BuiltUpColumn.Services
{
    public static class PluginDataMapper
    {
        public static BuiltUpColumnData Map(PluginData data)
        {
            var lacing = CreatePart(data.L_Profile, data.L_Material, data.L_PartPref, data.L_PartNo, data.L_AssyPref, data.L_AssyNo, data.L_Name, data.L_Class, data.L_UDA);

            var colData = new BuiltUpColumnData
            {
                Bcol = data.Bcol,
                Br_Rot = data.Br_Rot,
                Hcol_1 = data.Hcol_1,
                Hcol_e1 = data.Hcol_e1,
                Hcol_e2 = data.Hcol_e2,
                Hcol_e3 = data.Hcol_e3,

                SplicesText = data.SplicesText,
                Splice1Component = data.Splice1Component,
                Splice1Preset = data.Splice1Preset,
                Splice2Component = data.Splice2Component,
                Splice2Preset = data.Splice2Preset,
                Splice2Indexes = data.Splice2Indexes,
                Splice3Component = data.Splice3Component,
                Splice3Preset = data.Splice3Preset,
                Splice3Indexes = data.Splice3Indexes,
                Splice4Component = data.Splice4Component,
                Splice4Preset = data.Splice4Preset,
                Splice4Indexes = data.Splice4Indexes,
                Splice5Component = data.Splice5Component,
                Splice5Preset = data.Splice5Preset,
                Splice5Indexes = data.Splice5Indexes,

                L_StepMode = data.L_StepMode,
                L_StepText = data.L_StepText,
                L_Rasc = data.L_Rasc,
                L_Rasc_Base = data.L_Rasc_Base,
                L_Rasc_Top = data.L_Rasc_Top,
                L_RascOverrides = data.L_RascOverrides,
                L_Type = data.L_Type,
                L_Preset = data.L_Preset,
                L_Offset = data.L_Offset,

                // --- МОСТ ALPHA 1.2 ЗАМКНУТ ---
                L_Invert = data.L_Invert,
                L_Exclude = data.L_Exclude ?? "",
                L_HoldPhase = data.L_HoldPhase,
                L_MinRemainder = data.L_MinRemainder,
                L_RemainPanels = data.L_RemainPanels,
                S_KeyElev_Preset = data.S_KeyElev_Preset,
                L_MergePanels = data.L_MergePanels,

                // --- ALPHA 1.3 ЗАМКНУТ ---
                D1_CutComp = data.D1_CutComp,
                D1_CutAttr = data.D1_CutAttr,
                D2_CutComp = data.D2_CutComp,
                D2_CutAttr = data.D2_CutAttr,
                GP_CutMode = data.GP_CutMode,
                D1_CutMode = data.D1_CutMode,
                D2_CutMode = data.D2_CutMode,
                D_GapW = data.D_GapW,
                D_GapL = data.D_GapL,

                D1_PosPlane = data.D1_PosPlane,
                D1_PosPlaneOff = data.D1_PosPlaneOff,
                D1_PosRot = data.D1_PosRot,
                D1_PosRotOff = data.D1_PosRotOff,
                D1_PosDepth = data.D1_PosDepth,
                D1_PosDepthOff = data.D1_PosDepthOff,

                D2_PosPlane = data.D2_PosPlane,
                D2_PosPlaneOff = data.D2_PosPlaneOff,
                D2_PosRot = data.D2_PosRot,
                D2_PosRotOff = data.D2_PosRotOff,
                D2_PosDepth = data.D2_PosDepth,
                D2_PosDepthOff = data.D2_PosDepthOff,

                S_Base_Preset = data.S_Base_Preset,
                S_Top_Preset = data.S_Top_Preset,
                S_Splice_Preset = data.S_Splice_Preset,
                S_Preset = data.S_Preset,
                S_NodesAngle = data.S_NodesAngle,
                S_NodesAnglePlate = data.S_NodesAnglePlate,
                S_NodesD1 = data.S_NodesD1,
                S_NodesD2 = data.S_NodesD2,
                S_NodesExcludePlate = data.S_NodesExcludePlate,
                S_NodesExclude = data.S_NodesExclude,

                // --- ALPHA 1.4: НАДКОЛОННИК ---
                NK_Mode = data.NK_Mode,
                NK_HeightType = data.NK_HeightType,
                NK_Value = data.NK_Value,
                NK_Offset = data.NK_Offset,
                NK_Rot = data.NK_Rot,

				// --- ALPHA 1.6.1: СМЕЩЕНИЯ ---
				Global_Dx = data.Global_Dx,
				Global_Dy = data.Global_Dy,
				Global_Rot = data.Global_Rot,

				// --- ALPHA 1.6.2: ОГОЛОВОК ---
				Head_Type = data.Head_Type,
				HB_OverhangLeft = data.HB_OverhangLeft,
				HB_OverhangRight = data.HB_OverhangRight,
				HB_PosPlane = data.HB_PosPlane,
				HB_PosPlaneOff = data.HB_PosPlaneOff,
				HB_PosRot = data.HB_PosRot,
				HB_PosRotOff = data.HB_PosRotOff,
				HB_PosDepth = data.HB_PosDepth,
				HB_PosDepthOff = data.HB_PosDepthOff,

				SupColumn = CreatePart(data.NK_Profile, data.NK_Material, data.NK_PartPref, data.NK_PartNo, data.NK_AssyPref, data.NK_AssyNo, data.NK_Name, data.NK_Class, data.NK_UDA),
				HeadBeam = CreatePart(data.HB_Profile, data.HB_Material, data.HB_PartPref, data.HB_PartNo, data.HB_AssyPref, data.HB_AssyNo, data.HB_Name, data.HB_Class, data.HB_UDA),
				Branch = CreatePart(data.B_Profile, data.B_Material, data.B_PartPref, data.B_PartNo, data.B_AssyPref, data.B_AssyNo, data.B_Name, data.B_Class, data.B_UDA),
                Diaphragm1 = CreatePart(data.D_Profile, data.D_Material, data.D_PartPref, data.D_PartNo, data.D_AssyPref, data.D_AssyNo, data.D_Name, data.D_Class, data.D_UDA),
                Diaphragm2 = CreatePart(data.D2_Profile, data.D2_Material, data.D2_PartPref, data.D2_PartNo, data.D2_AssyPref, data.D2_AssyNo, data.D2_Name, data.D2_Class, data.D2_UDA),

                Lacing = lacing,
                LacingSplice = CreatePartWithFallback(data.LS_Profile, data.LS_Material, data.LS_PartPref, data.LS_PartNo, data.LS_AssyPref, data.LS_AssyNo, data.LS_Name, data.LS_Class, data.LS_UDA, lacing),
                Strut = CreatePartWithFallback(data.S_Profile, data.S_Material, data.S_PartPref, data.S_PartNo, data.S_AssyPref, data.S_AssyNo, data.S_Name, data.S_Class, data.S_UDA, lacing),
                // Забираем GP_Thickness из UI и вклеиваем в профиль донора "PL{t}*200"
                GussetPlate = CreatePart($"PL{data.GP_Thickness}*200", data.GP_Material, data.GP_PartPref, data.GP_PartNo, data.GP_AssyPref, data.GP_AssyNo, data.GP_Name, data.GP_Class, data.GP_UDA)
            };

            return colData;
        }

        private static PartSettings CreatePart(string prof, string mat, string pPref, string pNo, string aPref, string aNo, string name, string cls, string uda)
        {
            return new PartSettings { Profile = prof, Material = mat, PartPrefix = pPref, PartStartNo = ParseInt(pNo), AssemblyPrefix = aPref, AssemblyStartNo = ParseInt(aNo), Name = name, Class = cls, UDA = uda };
        }

        private static PartSettings CreatePartWithFallback(string prof, string mat, string pPref, string pNo, string aPref, string aNo, string name, string cls, string uda, PartSettings fallback)
        {
            return new PartSettings
            {
                Profile = string.IsNullOrWhiteSpace(prof) ? fallback.Profile : prof,
                Material = string.IsNullOrWhiteSpace(mat) ? fallback.Material : mat,
                PartPrefix = string.IsNullOrWhiteSpace(pPref) ? fallback.PartPrefix : pPref,
                PartStartNo = string.IsNullOrWhiteSpace(pNo) ? fallback.PartStartNo : ParseInt(pNo),
                AssemblyPrefix = string.IsNullOrWhiteSpace(aPref) ? fallback.AssemblyPrefix : aPref,
                AssemblyStartNo = string.IsNullOrWhiteSpace(aNo) ? fallback.AssemblyStartNo : ParseInt(aNo),
                Name = string.IsNullOrWhiteSpace(name) ? fallback.Name : name,
                Class = string.IsNullOrWhiteSpace(cls) ? fallback.Class : cls,
                UDA = string.IsNullOrWhiteSpace(uda) ? fallback.UDA : uda
            };
        }

        private static int ParseInt(string value, int fallback = 1) { return int.TryParse(value, out int result) ? result : fallback; }
    }
}