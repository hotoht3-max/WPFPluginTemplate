using Tekla.Structures.Dialog;
using WPFPluginTemplate;
using TD = Tekla.Structures.Datatype;

namespace Apibim.Plugins.BuiltUpColumn
{
    public class MainWindowViewModel : BaseViewModel
    {
        // =========================================================
        // ВНУТРЕННИЕ ПОЛЯ (Backing fields)
        // =========================================================
        private double _bcol = 500.0; private double _br_Rot = 90.0;
        private double _hcol_1 = 10000.0; private double _hcol_e1 = 500.0; private double _hcol_e2 = 600.0; private double _hcol_e3 = 600.0;

        private string _splicesText = "";
        private string _splice1Component = "77"; private string _splice1Preset = "standard";
        private string _splice2Component = ""; private string _splice2Preset = ""; private string _splice2Indexes = "";
        private string _splice3Component = ""; private string _splice3Preset = ""; private string _splice3Indexes = "";
        private string _splice4Component = ""; private string _splice4Preset = ""; private string _splice4Indexes = "";
        private string _splice5Component = ""; private string _splice5Preset = ""; private string _splice5Indexes = "";

        private int _l_StepMode = 0; private string _l_StepText = "";
        private double _l_MinRemainder = 0.0; private int _l_MergePanels = 2; private int _l_RemainPanels = 2;
        private int _l_Invert = 0; private string _l_Exclude = ""; private int _l_HoldPhase = 0;
        private double _l_Rasc = 50.0; private double _l_Rasc_Base = 50.0; private double _l_Rasc_Top = 50.0; private string _l_RascOverrides = "";
        private int _l_Type = 1; private int _l_Preset = 1; private double _l_Offset = 0.0;

        private int _s_Base_Preset = 2; private int _s_Top_Preset = 2; private int _s_Splice_Preset = 2; private int _s_KeyElev_Preset = 0; private int _s_Preset = 1;
        private string _s_NodesAngle = ""; private string _s_NodesAnglePlate = ""; private string _s_NodesD1 = ""; private string _s_NodesD2 = ""; private string _s_NodesExcludePlate = ""; private string _s_NodesExclude = "";

        private int _gp_CutMode = 0; 
        private int _d1_CutMode = 1; private int _d2_CutMode = 1; private double _d_GapW = 0.0; private double _d_GapL = 0.0;
        private int _d1_PosPlane = 0; private double _d1_PosPlaneOff = 0.0; private int _d1_PosRot = 0; private double _d1_PosRotOff = 0.0; private int _d1_PosDepth = 0; private double _d1_PosDepthOff = 0.0;
        private int _d2_PosPlane = 0; private double _d2_PosPlaneOff = 0.0; private int _d2_PosRot = 0; private double _d2_PosRotOff = 0.0; private int _d2_PosDepth = 0; private double _d2_PosDepthOff = 0.0;

        private string _b_Profile = "I20K1_57837_2017"; private string _b_Material = "C355Б"; private string _b_AssyPref = "К"; private string _b_AssyNo = "1"; private string _b_PartPref = "к"; private string _b_PartNo = "1"; private string _b_Name = "ВЕТВЬ"; private string _b_Class = "1"; private string _b_uda = "";
        private string _d_Profile = "16P_8240_97"; private string _d_Material = "C245"; private string _d_AssyPref = ""; private string _d_AssyNo = ""; private string _d_PartPref = "д1"; private string _d_PartNo = "1"; private string _d_Name = "ДИАФРАГМА 1"; private string _d_Class = "4"; private string _d_uda = "";
        private string _d2_Profile = "20B1_57837_2017"; private string _d2_Material = "C245"; private string _d2_AssyPref = ""; private string _d2_AssyNo = ""; private string _d2_PartPref = "д2"; private string _d2_PartNo = "1"; private string _d2_Name = "ДИАФРАГМА 2"; private string _d2_Class = "4"; private string _d2_uda = "";
        private string _l_Profile = "L75X6_8509_93"; private string _l_Material = "C245"; private string _l_AssyPref = ""; private string _l_AssyNo = ""; private string _l_PartPref = "р"; private string _l_PartNo = "1"; private string _l_Name = "РАСКОС"; private string _l_Class = "3"; private string _l_uda = "";
        private string _ls_Profile = ""; private string _ls_Material = ""; private string _ls_AssyPref = ""; private string _ls_AssyNo = ""; private string _ls_PartPref = "рс"; private string _ls_PartNo = "1"; private string _ls_Name = "РАСКОС СТЫКОВОЙ"; private string _ls_Class = "3"; private string _ls_uda = "";
        private string _s_Profile = ""; private string _s_Material = ""; private string _s_AssyPref = ""; private string _s_AssyNo = ""; private string _s_PartPref = "рп"; private string _s_PartNo = "1"; private string _s_Name = "РАСПОРКА"; private string _s_Class = "4"; private string _s_uda = "";
        private string _gp_Thickness = "10"; private string _gp_Material = "C245"; private string _gp_AssyPref = ""; private string _gp_AssyNo = ""; private string _gp_PartPref = "пл"; private string _gp_PartNo = "1"; private string _gp_Name = "ЛИСТ РАСПОРКИ"; private string _gp_Class = "99"; private string _gp_uda = "";
        private string _d1_CutComp = "123"; private string _d1_CutAttr = "standard"; private string _d2_CutComp = "123"; private string _d2_CutAttr = "standard";

        // Надколонник (Альфа 1.4)
        private int _nk_Mode = 0; private int _nk_HeightType = 0; private double _nk_Value = 1000.0; private double _nk_Offset = 0.0; private double _nk_Rot = 0.0;
        private string _nk_Profile = "40K1_57837_2017"; private string _nk_Material = "C355Б"; private string _nk_AssyPref = "К"; private string _nk_AssyNo = "1"; private string _nk_PartPref = "нк"; private string _nk_PartNo = "1"; private string _nk_Name = "НАДКОЛОННИК"; private string _nk_Class = "1"; private string _nk_uda = "";

        // Смещения (Alpha 1.6.1)
        private double _global_Dx = 0.0; private double _global_Dy = 0.0; private double _global_Rot = 0.0;

        // Оголовок (Alpha 1.6.2)
        private int _head_Type = 0;
        private double _hb_OverhangLeft = 0.0; private double _hb_OverhangRight = 0.0;
        private int _hb_PosPlane = 0; private double _hb_PosPlaneOff = 0.0;
        private int _hb_PosRot = 0; private double _hb_PosRotOff = 0.0;
        private int _hb_PosDepth = 2; private double _hb_PosDepthOff = 0.0;
        private string _hb_Profile = "40B1_57837_2017"; private string _hb_Material = "C245";
        private string _hb_AssyPref = "Б"; private string _hb_AssyNo = "1";
        private string _hb_PartPref = "б"; private string _hb_PartNo = "1";
        private string _hb_Name = "БАЛКА ОГОЛОВКА"; private string _hb_Class = "6"; private string _hb_UDA = "";

        // Узлы балки (Alpha 1.6.3)
        private int _hb_C1_Main = 0; private string _hb_C1_Comp = ""; private string _hb_C1_Attr = "";
        private int _hb_C2_Main = 0; private string _hb_C2_Comp = ""; private string _hb_C2_Attr = "";
        private string _hb_T1_Comp = ""; private string _hb_T1_Attr = "";
        private string _hb_T2_Comp = ""; private string _hb_T2_Attr = "";

        // =========================================================
        // СВОЙСТВА (Properties for Binding)
        // =========================================================

        [StructuresDialog("Bcol", typeof(TD.Double))] public double Bcol { get => _bcol; set => Set(ref _bcol, value); }
        [StructuresDialog("Br_Rot", typeof(TD.Double))] public double Br_Rot { get => _br_Rot; set => Set(ref _br_Rot, value); }
        [StructuresDialog("Hcol_1", typeof(TD.Double))] public double Hcol_1 { get => _hcol_1; set => Set(ref _hcol_1, value); }
        [StructuresDialog("Hcol_e1", typeof(TD.Double))] public double Hcol_e1 { get => _hcol_e1; set => Set(ref _hcol_e1, value); }
        [StructuresDialog("Hcol_e2", typeof(TD.Double))] public double Hcol_e2 { get => _hcol_e2; set => Set(ref _hcol_e2, value); }
        [StructuresDialog("Hcol_e3", typeof(TD.Double))] public double Hcol_e3 { get => _hcol_e3; set => Set(ref _hcol_e3, value); }

        [StructuresDialog("SplicesText", typeof(TD.String))] public string SplicesText { get => _splicesText; set => Set(ref _splicesText, value); }
        [StructuresDialog("Splice1Component", typeof(TD.String))] public string Splice1Component { get => _splice1Component; set => Set(ref _splice1Component, value); }
        [StructuresDialog("Splice1Preset", typeof(TD.String))] public string Splice1Preset { get => _splice1Preset; set => Set(ref _splice1Preset, value); }
        [StructuresDialog("Splice2Component", typeof(TD.String))] public string Splice2Component { get => _splice2Component; set => Set(ref _splice2Component, value); }
        [StructuresDialog("Splice2Preset", typeof(TD.String))] public string Splice2Preset { get => _splice2Preset; set => Set(ref _splice2Preset, value); }
        [StructuresDialog("Splice2Indexes", typeof(TD.String))] public string Splice2Indexes { get => _splice2Indexes; set => Set(ref _splice2Indexes, value); }
        [StructuresDialog("Splice3Component", typeof(TD.String))] public string Splice3Component { get => _splice3Component; set => Set(ref _splice3Component, value); }
        [StructuresDialog("Splice3Preset", typeof(TD.String))] public string Splice3Preset { get => _splice3Preset; set => Set(ref _splice3Preset, value); }
        [StructuresDialog("Splice3Indexes", typeof(TD.String))] public string Splice3Indexes { get => _splice3Indexes; set => Set(ref _splice3Indexes, value); }
        [StructuresDialog("Splice4Component", typeof(TD.String))] public string Splice4Component { get => _splice4Component; set => Set(ref _splice4Component, value); }
        [StructuresDialog("Splice4Preset", typeof(TD.String))] public string Splice4Preset { get => _splice4Preset; set => Set(ref _splice4Preset, value); }
        [StructuresDialog("Splice4Indexes", typeof(TD.String))] public string Splice4Indexes { get => _splice4Indexes; set => Set(ref _splice4Indexes, value); }
        [StructuresDialog("Splice5Component", typeof(TD.String))] public string Splice5Component { get => _splice5Component; set => Set(ref _splice5Component, value); }
        [StructuresDialog("Splice5Preset", typeof(TD.String))] public string Splice5Preset { get => _splice5Preset; set => Set(ref _splice5Preset, value); }
        [StructuresDialog("Splice5Indexes", typeof(TD.String))] public string Splice5Indexes { get => _splice5Indexes; set => Set(ref _splice5Indexes, value); }

        [StructuresDialog("L_StepMode", typeof(TD.Integer))] public int L_StepMode { get => _l_StepMode; set => Set(ref _l_StepMode, value); }
        [StructuresDialog("L_StepText", typeof(TD.String))] public string L_StepText { get => _l_StepText; set => Set(ref _l_StepText, value); }
        [StructuresDialog("L_MinRemainder", typeof(TD.Double))] public double L_MinRemainder { get => _l_MinRemainder; set => Set(ref _l_MinRemainder, value); }
        [StructuresDialog("L_MergePanels", typeof(TD.Integer))] public int L_MergePanels { get => _l_MergePanels; set => Set(ref _l_MergePanels, value); }
        [StructuresDialog("L_RemainPanels", typeof(TD.Integer))] public int L_RemainPanels { get => _l_RemainPanels; set => Set(ref _l_RemainPanels, value); }

        [StructuresDialog("L_Invert", typeof(TD.Integer))] public int L_Invert { get => _l_Invert; set => Set(ref _l_Invert, value); }
        [StructuresDialog("L_Exclude", typeof(TD.String))] public string L_Exclude { get => _l_Exclude; set => Set(ref _l_Exclude, value); }
        [StructuresDialog("L_HoldPhase", typeof(TD.Integer))] public int L_HoldPhase { get => _l_HoldPhase; set => Set(ref _l_HoldPhase, value); }

        [StructuresDialog("L_Rasc", typeof(TD.Double))] public double L_Rasc { get => _l_Rasc; set => Set(ref _l_Rasc, value); }
        [StructuresDialog("L_Rasc_Base", typeof(TD.Double))] public double L_Rasc_Base { get => _l_Rasc_Base; set => Set(ref _l_Rasc_Base, value); }
        [StructuresDialog("L_Rasc_Top", typeof(TD.Double))] public double L_Rasc_Top { get => _l_Rasc_Top; set => Set(ref _l_Rasc_Top, value); }
        [StructuresDialog("L_RascOverrides", typeof(TD.String))] public string L_RascOverrides { get => _l_RascOverrides; set => Set(ref _l_RascOverrides, value); }
        [StructuresDialog("L_Type", typeof(TD.Integer))] public int L_Type { get => _l_Type; set => Set(ref _l_Type, value); }
        [StructuresDialog("L_Preset", typeof(TD.Integer))] public int L_Preset { get => _l_Preset; set => Set(ref _l_Preset, value); }
        [StructuresDialog("L_Offset", typeof(TD.Double))] public double L_Offset { get => _l_Offset; set => Set(ref _l_Offset, value); }

        [StructuresDialog("S_Base_Preset", typeof(TD.Integer))] public int S_Base_Preset { get => _s_Base_Preset; set => Set(ref _s_Base_Preset, value); }
        [StructuresDialog("S_Top_Preset", typeof(TD.Integer))] public int S_Top_Preset { get => _s_Top_Preset; set => Set(ref _s_Top_Preset, value); }
        [StructuresDialog("S_Splice_Preset", typeof(TD.Integer))] public int S_Splice_Preset { get => _s_Splice_Preset; set => Set(ref _s_Splice_Preset, value); }
        [StructuresDialog("S_KeyElev_Preset", typeof(TD.Integer))] public int S_KeyElev_Preset { get => _s_KeyElev_Preset; set => Set(ref _s_KeyElev_Preset, value); }
        [StructuresDialog("S_Preset", typeof(TD.Integer))] public int S_Preset { get => _s_Preset; set => Set(ref _s_Preset, value); }
        [StructuresDialog("S_NodesAngle", typeof(TD.String))] public string S_NodesAngle { get => _s_NodesAngle; set => Set(ref _s_NodesAngle, value); }
        [StructuresDialog("S_NodesAnglePlate", typeof(TD.String))] public string S_NodesAnglePlate { get => _s_NodesAnglePlate; set => Set(ref _s_NodesAnglePlate, value); }
        [StructuresDialog("S_NodesD1", typeof(TD.String))] public string S_NodesD1 { get => _s_NodesD1; set => Set(ref _s_NodesD1, value); }
        [StructuresDialog("S_NodesD2", typeof(TD.String))] public string S_NodesD2 { get => _s_NodesD2; set => Set(ref _s_NodesD2, value); }
        [StructuresDialog("S_NodesExcludePlate", typeof(TD.String))] public string S_NodesExcludePlate { get => _s_NodesExcludePlate; set => Set(ref _s_NodesExcludePlate, value); }
        [StructuresDialog("S_NodesExclude", typeof(TD.String))] public string S_NodesExclude { get => _s_NodesExclude; set => Set(ref _s_NodesExclude, value); }

        [StructuresDialog("GP_CutMode", typeof(TD.Integer))] public int GP_CutMode { get => _gp_CutMode; set => Set(ref _gp_CutMode, value); }
        [StructuresDialog("D1_CutComp", typeof(TD.String))] public string D1_CutComp { get => _d1_CutComp; set => Set(ref _d1_CutComp, value); }
        [StructuresDialog("D1_CutAttr", typeof(TD.String))] public string D1_CutAttr { get => _d1_CutAttr; set => Set(ref _d1_CutAttr, value); }
        [StructuresDialog("D2_CutComp", typeof(TD.String))] public string D2_CutComp { get => _d2_CutComp; set => Set(ref _d2_CutComp, value); }
        [StructuresDialog("D2_CutAttr", typeof(TD.String))] public string D2_CutAttr { get => _d2_CutAttr; set => Set(ref _d2_CutAttr, value); }
        [StructuresDialog("D1_CutMode", typeof(TD.Integer))] public int D1_CutMode { get => _d1_CutMode; set => Set(ref _d1_CutMode, value); }
        [StructuresDialog("D2_CutMode", typeof(TD.Integer))] public int D2_CutMode { get => _d2_CutMode; set => Set(ref _d2_CutMode, value); }
        [StructuresDialog("D_GapW", typeof(TD.Double))] public double D_GapW { get => _d_GapW; set => Set(ref _d_GapW, value); }
        [StructuresDialog("D_GapL", typeof(TD.Double))] public double D_GapL { get => _d_GapL; set => Set(ref _d_GapL, value); }

        [StructuresDialog("D1_PosPlane", typeof(TD.Integer))] public int D1_PosPlane { get => _d1_PosPlane; set => Set(ref _d1_PosPlane, value); }
        [StructuresDialog("D1_PosPlaneOff", typeof(TD.Double))] public double D1_PosPlaneOff { get => _d1_PosPlaneOff; set => Set(ref _d1_PosPlaneOff, value); }
        [StructuresDialog("D1_PosRot", typeof(TD.Integer))] public int D1_PosRot { get => _d1_PosRot; set => Set(ref _d1_PosRot, value); }
        [StructuresDialog("D1_PosRotOff", typeof(TD.Double))] public double D1_PosRotOff { get => _d1_PosRotOff; set => Set(ref _d1_PosRotOff, value); }
        [StructuresDialog("D1_PosDepth", typeof(TD.Integer))] public int D1_PosDepth { get => _d1_PosDepth; set => Set(ref _d1_PosDepth, value); }
        [StructuresDialog("D1_PosDepthOff", typeof(TD.Double))] public double D1_PosDepthOff { get => _d1_PosDepthOff; set => Set(ref _d1_PosDepthOff, value); }

        [StructuresDialog("D2_PosPlane", typeof(TD.Integer))] public int D2_PosPlane { get => _d2_PosPlane; set => Set(ref _d2_PosPlane, value); }
        [StructuresDialog("D2_PosPlaneOff", typeof(TD.Double))] public double D2_PosPlaneOff { get => _d2_PosPlaneOff; set => Set(ref _d2_PosPlaneOff, value); }
        [StructuresDialog("D2_PosRot", typeof(TD.Integer))] public int D2_PosRot { get => _d2_PosRot; set => Set(ref _d2_PosRot, value); }
        [StructuresDialog("D2_PosRotOff", typeof(TD.Double))] public double D2_PosRotOff { get => _d2_PosRotOff; set => Set(ref _d2_PosRotOff, value); }
        [StructuresDialog("D2_PosDepth", typeof(TD.Integer))] public int D2_PosDepth { get => _d2_PosDepth; set => Set(ref _d2_PosDepth, value); }
        [StructuresDialog("D2_PosDepthOff", typeof(TD.Double))] public double D2_PosDepthOff { get => _d2_PosDepthOff; set => Set(ref _d2_PosDepthOff, value); }

        [StructuresDialog("B_Profile", typeof(TD.String))] public string B_Profile { get => _b_Profile; set => Set(ref _b_Profile, value); }
        [StructuresDialog("B_Material", typeof(TD.String))] public string B_Material { get => _b_Material; set => Set(ref _b_Material, value); }
        [StructuresDialog("B_AssyPref", typeof(TD.String))] public string B_AssyPref { get => _b_AssyPref; set => Set(ref _b_AssyPref, value); }
        [StructuresDialog("B_AssyNo", typeof(TD.String))] public string B_AssyNo { get => _b_AssyNo; set => Set(ref _b_AssyNo, value); }
        [StructuresDialog("B_PartPref", typeof(TD.String))] public string B_PartPref { get => _b_PartPref; set => Set(ref _b_PartPref, value); }
        [StructuresDialog("B_PartNo", typeof(TD.String))] public string B_PartNo { get => _b_PartNo; set => Set(ref _b_PartNo, value); }
        [StructuresDialog("B_Name", typeof(TD.String))] public string B_Name { get => _b_Name; set => Set(ref _b_Name, value); }
        [StructuresDialog("B_Class", typeof(TD.String))] public string B_Class { get => _b_Class; set => Set(ref _b_Class, value); }
        [StructuresDialog("B_UDA", typeof(TD.String))] public string B_UDA { get => _b_uda; set => Set(ref _b_uda, value); }

        [StructuresDialog("D_Profile", typeof(TD.String))] public string D_Profile { get => _d_Profile; set => Set(ref _d_Profile, value); }
        [StructuresDialog("D_Material", typeof(TD.String))] public string D_Material { get => _d_Material; set => Set(ref _d_Material, value); }
        [StructuresDialog("D_AssyPref", typeof(TD.String))] public string D_AssyPref { get => _d_AssyPref; set => Set(ref _d_AssyPref, value); }
        [StructuresDialog("D_AssyNo", typeof(TD.String))] public string D_AssyNo { get => _d_AssyNo; set => Set(ref _d_AssyNo, value); }
        [StructuresDialog("D_PartPref", typeof(TD.String))] public string D_PartPref { get => _d_PartPref; set => Set(ref _d_PartPref, value); }
        [StructuresDialog("D_PartNo", typeof(TD.String))] public string D_PartNo { get => _d_PartNo; set => Set(ref _d_PartNo, value); }
        [StructuresDialog("D_Name", typeof(TD.String))] public string D_Name { get => _d_Name; set => Set(ref _d_Name, value); }
        [StructuresDialog("D_Class", typeof(TD.String))] public string D_Class { get => _d_Class; set => Set(ref _d_Class, value); }
        [StructuresDialog("D_UDA", typeof(TD.String))] public string D_UDA { get => _d_uda; set => Set(ref _d_uda, value); }

        [StructuresDialog("D2_Profile", typeof(TD.String))] public string D2_Profile { get => _d2_Profile; set => Set(ref _d2_Profile, value); }
        [StructuresDialog("D2_Material", typeof(TD.String))] public string D2_Material { get => _d2_Material; set => Set(ref _d2_Material, value); }
        [StructuresDialog("D2_AssyPref", typeof(TD.String))] public string D2_AssyPref { get => _d2_AssyPref; set => Set(ref _d2_AssyPref, value); }
        [StructuresDialog("D2_AssyNo", typeof(TD.String))] public string D2_AssyNo { get => _d2_AssyNo; set => Set(ref _d2_AssyNo, value); }
        [StructuresDialog("D2_PartPref", typeof(TD.String))] public string D2_PartPref { get => _d2_PartPref; set => Set(ref _d2_PartPref, value); }
        [StructuresDialog("D2_PartNo", typeof(TD.String))] public string D2_PartNo { get => _d2_PartNo; set => Set(ref _d2_PartNo, value); }
        [StructuresDialog("D2_Name", typeof(TD.String))] public string D2_Name { get => _d2_Name; set => Set(ref _d2_Name, value); }
        [StructuresDialog("D2_Class", typeof(TD.String))] public string D2_Class { get => _d2_Class; set => Set(ref _d2_Class, value); }
        [StructuresDialog("D2_UDA", typeof(TD.String))] public string D2_UDA { get => _d2_uda; set => Set(ref _d2_uda, value); }

        [StructuresDialog("L_Profile", typeof(TD.String))] public string L_Profile { get => _l_Profile; set => Set(ref _l_Profile, value); }
        [StructuresDialog("L_Material", typeof(TD.String))] public string L_Material { get => _l_Material; set => Set(ref _l_Material, value); }
        [StructuresDialog("L_AssyPref", typeof(TD.String))] public string L_AssyPref { get => _l_AssyPref; set => Set(ref _l_AssyPref, value); }
        [StructuresDialog("L_AssyNo", typeof(TD.String))] public string L_AssyNo { get => _l_AssyNo; set => Set(ref _l_AssyNo, value); }
        [StructuresDialog("L_PartPref", typeof(TD.String))] public string L_PartPref { get => _l_PartPref; set => Set(ref _l_PartPref, value); }
        [StructuresDialog("L_PartNo", typeof(TD.String))] public string L_PartNo { get => _l_PartNo; set => Set(ref _l_PartNo, value); }
        [StructuresDialog("L_Name", typeof(TD.String))] public string L_Name { get => _l_Name; set => Set(ref _l_Name, value); }
        [StructuresDialog("L_Class", typeof(TD.String))] public string L_Class { get => _l_Class; set => Set(ref _l_Class, value); }
        [StructuresDialog("L_UDA", typeof(TD.String))] public string L_UDA { get => _l_uda; set => Set(ref _l_uda, value); }

        [StructuresDialog("LS_Profile", typeof(TD.String))] public string LS_Profile { get => _ls_Profile; set => Set(ref _ls_Profile, value); }
        [StructuresDialog("LS_Material", typeof(TD.String))] public string LS_Material { get => _ls_Material; set => Set(ref _ls_Material, value); }
        [StructuresDialog("LS_AssyPref", typeof(TD.String))] public string LS_AssyPref { get => _ls_AssyPref; set => Set(ref _ls_AssyPref, value); }
        [StructuresDialog("LS_AssyNo", typeof(TD.String))] public string LS_AssyNo { get => _ls_AssyNo; set => Set(ref _ls_AssyNo, value); }
        [StructuresDialog("LS_PartPref", typeof(TD.String))] public string LS_PartPref { get => _ls_PartPref; set => Set(ref _ls_PartPref, value); }
        [StructuresDialog("LS_PartNo", typeof(TD.String))] public string LS_PartNo { get => _ls_PartNo; set => Set(ref _ls_PartNo, value); }
        [StructuresDialog("LS_Name", typeof(TD.String))] public string LS_Name { get => _ls_Name; set => Set(ref _ls_Name, value); }
        [StructuresDialog("LS_Class", typeof(TD.String))] public string LS_Class { get => _ls_Class; set => Set(ref _ls_Class, value); }
        [StructuresDialog("LS_UDA", typeof(TD.String))] public string LS_UDA { get => _ls_uda; set => Set(ref _ls_uda, value); }

        [StructuresDialog("S_Profile", typeof(TD.String))] public string S_Profile { get => _s_Profile; set => Set(ref _s_Profile, value); }
        [StructuresDialog("S_Material", typeof(TD.String))] public string S_Material { get => _s_Material; set => Set(ref _s_Material, value); }
        [StructuresDialog("S_AssyPref", typeof(TD.String))] public string S_AssyPref { get => _s_AssyPref; set => Set(ref _s_AssyPref, value); }
        [StructuresDialog("S_AssyNo", typeof(TD.String))] public string S_AssyNo { get => _s_AssyNo; set => Set(ref _s_AssyNo, value); }
        [StructuresDialog("S_PartPref", typeof(TD.String))] public string S_PartPref { get => _s_PartPref; set => Set(ref _s_PartPref, value); }
        [StructuresDialog("S_PartNo", typeof(TD.String))] public string S_PartNo { get => _s_PartNo; set => Set(ref _s_PartNo, value); }
        [StructuresDialog("S_Name", typeof(TD.String))] public string S_Name { get => _s_Name; set => Set(ref _s_Name, value); }
        [StructuresDialog("S_Class", typeof(TD.String))] public string S_Class { get => _s_Class; set => Set(ref _s_Class, value); }
        [StructuresDialog("S_UDA", typeof(TD.String))] public string S_UDA { get => _s_uda; set => Set(ref _s_uda, value); }

        [StructuresDialog("GP_Thickness", typeof(TD.String))] public string GP_Thickness { get => _gp_Thickness; set => Set(ref _gp_Thickness, value); }
        [StructuresDialog("GP_Material", typeof(TD.String))] public string GP_Material { get => _gp_Material; set => Set(ref _gp_Material, value); }
        [StructuresDialog("GP_AssyPref", typeof(TD.String))] public string GP_AssyPref { get => _gp_AssyPref; set => Set(ref _gp_AssyPref, value); }
        [StructuresDialog("GP_AssyNo", typeof(TD.String))] public string GP_AssyNo { get => _gp_AssyNo; set => Set(ref _gp_AssyNo, value); }
        [StructuresDialog("GP_PartPref", typeof(TD.String))] public string GP_PartPref { get => _gp_PartPref; set => Set(ref _gp_PartPref, value); }
        [StructuresDialog("GP_PartNo", typeof(TD.String))] public string GP_PartNo { get => _gp_PartNo; set => Set(ref _gp_PartNo, value); }
        [StructuresDialog("GP_Name", typeof(TD.String))] public string GP_Name { get => _gp_Name; set => Set(ref _gp_Name, value); }
        [StructuresDialog("GP_Class", typeof(TD.String))] public string GP_Class { get => _gp_Class; set => Set(ref _gp_Class, value); }
        [StructuresDialog("GP_UDA", typeof(TD.String))] public string GP_UDA { get => _gp_uda; set => Set(ref _gp_uda, value); }

        // Надколонник (Альфа 1.4)
        [StructuresDialog("NK_Mode", typeof(TD.Integer))] public int NK_Mode { get => _nk_Mode; set => Set(ref _nk_Mode, value); }
        [StructuresDialog("NK_HeightType", typeof(TD.Integer))] public int NK_HeightType { get => _nk_HeightType; set => Set(ref _nk_HeightType, value); }
        [StructuresDialog("NK_Value", typeof(TD.Double))] public double NK_Value { get => _nk_Value; set => Set(ref _nk_Value, value); }
        [StructuresDialog("NK_Offset", typeof(TD.Double))] public double NK_Offset { get => _nk_Offset; set => Set(ref _nk_Offset, value); }
        [StructuresDialog("NK_Rot", typeof(TD.Double))] public double NK_Rot { get => _nk_Rot; set => Set(ref _nk_Rot, value); }

        [StructuresDialog("NK_Profile", typeof(TD.String))] public string NK_Profile { get => _nk_Profile; set => Set(ref _nk_Profile, value); }
        [StructuresDialog("NK_Material", typeof(TD.String))] public string NK_Material { get => _nk_Material; set => Set(ref _nk_Material, value); }
        [StructuresDialog("NK_AssyPref", typeof(TD.String))] public string NK_AssyPref { get => _nk_AssyPref; set => Set(ref _nk_AssyPref, value); }
        [StructuresDialog("NK_AssyNo", typeof(TD.String))] public string NK_AssyNo { get => _nk_AssyNo; set => Set(ref _nk_AssyNo, value); }
        [StructuresDialog("NK_PartPref", typeof(TD.String))] public string NK_PartPref { get => _nk_PartPref; set => Set(ref _nk_PartPref, value); }
        [StructuresDialog("NK_PartNo", typeof(TD.String))] public string NK_PartNo { get => _nk_PartNo; set => Set(ref _nk_PartNo, value); }
        [StructuresDialog("NK_Name", typeof(TD.String))] public string NK_Name { get => _nk_Name; set => Set(ref _nk_Name, value); }
        [StructuresDialog("NK_Class", typeof(TD.String))] public string NK_Class { get => _nk_Class; set => Set(ref _nk_Class, value); }
        [StructuresDialog("NK_UDA", typeof(TD.String))] public string NK_UDA { get => _nk_uda; set => Set(ref _nk_uda, value); }

        // Смещения Alpha 1.6.1
        [StructuresDialog("Global_Dx", typeof(TD.Double))] public double Global_Dx { get => _global_Dx; set => Set(ref _global_Dx, value); }
        [StructuresDialog("Global_Dy", typeof(TD.Double))] public double Global_Dy { get => _global_Dy; set => Set(ref _global_Dy, value); }
        [StructuresDialog("Global_Rot", typeof(TD.Double))] public double Global_Rot { get => _global_Rot; set => Set(ref _global_Rot, value); }

        // Оголовок Alpha 1.6.2
        [StructuresDialog("Head_Type", typeof(TD.Integer))] public int Head_Type { get => _head_Type; set => Set(ref _head_Type, value); }
        [StructuresDialog("HB_OverhangLeft", typeof(TD.Double))] public double HB_OverhangLeft { get => _hb_OverhangLeft; set => Set(ref _hb_OverhangLeft, value); }
        [StructuresDialog("HB_OverhangRight", typeof(TD.Double))] public double HB_OverhangRight { get => _hb_OverhangRight; set => Set(ref _hb_OverhangRight, value); }
        [StructuresDialog("HB_PosPlane", typeof(TD.Integer))] public int HB_PosPlane { get => _hb_PosPlane; set => Set(ref _hb_PosPlane, value); }
        [StructuresDialog("HB_PosPlaneOff", typeof(TD.Double))] public double HB_PosPlaneOff { get => _hb_PosPlaneOff; set => Set(ref _hb_PosPlaneOff, value); }
        [StructuresDialog("HB_PosRot", typeof(TD.Integer))] public int HB_PosRot { get => _hb_PosRot; set => Set(ref _hb_PosRot, value); }
        [StructuresDialog("HB_PosRotOff", typeof(TD.Double))] public double HB_PosRotOff { get => _hb_PosRotOff; set => Set(ref _hb_PosRotOff, value); }
        [StructuresDialog("HB_PosDepth", typeof(TD.Integer))] public int HB_PosDepth { get => _hb_PosDepth; set => Set(ref _hb_PosDepth, value); }
        [StructuresDialog("HB_PosDepthOff", typeof(TD.Double))] public double HB_PosDepthOff { get => _hb_PosDepthOff; set => Set(ref _hb_PosDepthOff, value); }
        [StructuresDialog("HB_Profile", typeof(TD.String))] public string HB_Profile { get => _hb_Profile; set => Set(ref _hb_Profile, value); }
        [StructuresDialog("HB_Material", typeof(TD.String))] public string HB_Material { get => _hb_Material; set => Set(ref _hb_Material, value); }
        [StructuresDialog("HB_AssyPref", typeof(TD.String))] public string HB_AssyPref { get => _hb_AssyPref; set => Set(ref _hb_AssyPref, value); }
        [StructuresDialog("HB_AssyNo", typeof(TD.String))] public string HB_AssyNo { get => _hb_AssyNo; set => Set(ref _hb_AssyNo, value); }
        [StructuresDialog("HB_PartPref", typeof(TD.String))] public string HB_PartPref { get => _hb_PartPref; set => Set(ref _hb_PartPref, value); }
        [StructuresDialog("HB_PartNo", typeof(TD.String))] public string HB_PartNo { get => _hb_PartNo; set => Set(ref _hb_PartNo, value); }
        [StructuresDialog("HB_Name", typeof(TD.String))] public string HB_Name { get => _hb_Name; set => Set(ref _hb_Name, value); }
        [StructuresDialog("HB_Class", typeof(TD.String))] public string HB_Class { get => _hb_Class; set => Set(ref _hb_Class, value); }
        [StructuresDialog("HB_UDA", typeof(TD.String))] public string HB_UDA { get => _hb_UDA; set => Set(ref _hb_UDA, value); }

        // Узлы балки Alpha 1.6.3
        [StructuresDialog("HB_C1_Main", typeof(TD.Integer))] public int HB_C1_Main { get => _hb_C1_Main; set => Set(ref _hb_C1_Main, value); }
        [StructuresDialog("HB_C1_Comp", typeof(TD.String))] public string HB_C1_Comp { get => _hb_C1_Comp; set => Set(ref _hb_C1_Comp, value); }
        [StructuresDialog("HB_C1_Attr", typeof(TD.String))] public string HB_C1_Attr { get => _hb_C1_Attr; set => Set(ref _hb_C1_Attr, value); }

        [StructuresDialog("HB_C2_Main", typeof(TD.Integer))] public int HB_C2_Main { get => _hb_C2_Main; set => Set(ref _hb_C2_Main, value); }
        [StructuresDialog("HB_C2_Comp", typeof(TD.String))] public string HB_C2_Comp { get => _hb_C2_Comp; set => Set(ref _hb_C2_Comp, value); }
        [StructuresDialog("HB_C2_Attr", typeof(TD.String))] public string HB_C2_Attr { get => _hb_C2_Attr; set => Set(ref _hb_C2_Attr, value); }

        [StructuresDialog("HB_T1_Comp", typeof(TD.String))] public string HB_T1_Comp { get => _hb_T1_Comp; set => Set(ref _hb_T1_Comp, value); }
        [StructuresDialog("HB_T1_Attr", typeof(TD.String))] public string HB_T1_Attr { get => _hb_T1_Attr; set => Set(ref _hb_T1_Attr, value); }

        [StructuresDialog("HB_T2_Comp", typeof(TD.String))] public string HB_T2_Comp { get => _hb_T2_Comp; set => Set(ref _hb_T2_Comp, value); }
        [StructuresDialog("HB_T2_Attr", typeof(TD.String))] public string HB_T2_Attr { get => _hb_T2_Attr; set => Set(ref _hb_T2_Attr, value); }
    }
}