using Tekla.Structures.Dialog;
using WPFPluginTemplate;
using TD = Tekla.Structures.Datatype;

namespace Apibim.Plugins.BuiltUpColumn
{
    public class MainWindowViewModel : BaseViewModel
    {
        private double _bcol = 500.0; private double _br_Rot = 90.0;
        private double _hcol_1 = 10000.0; private double _hcol_e1 = 500.0; private double _hcol_e2 = 600.0; private double _hcol_e3 = 600.0;
        private string _splicesText = "";
        private string _spliceComponent = "14";
        private string _splicePreset = "standard";

        private int _l_StepMode = 0; private double _hr_base = 1200.0; private string _l_StepText = "";
        private double _l_Rasc = 50.0; private double _l_Rasc_Base = 50.0; private double _l_Rasc_Top = 50.0; private string _l_RascOverrides = "";
        private int _l_Type = 1; private int _l_Preset = 1; private double _l_Offset = 0.0;

        private int _s_Mode = 0; private string _s_NodesDouble = ""; private string _s_NodesChannel = ""; private string _s_NodesExclude = "";
        private int _s_Base_Preset = 2; private int _s_Top_Preset = 2; private int _s_Splice_Preset = 2; private int _s_Preset = 1;

        // Ветвь
        private string _b_Profile = "I20K1_57837_2017"; private string _b_Material = "C355Б"; private string _b_AssyPref = "К"; private string _b_AssyNo = "1"; private string _b_PartPref = "к"; private string _b_PartNo = "1"; private string _b_Name = "ВЕТВЬ"; private string _b_Class = "1";
        // Диафрагма
        private string _d_Profile = "16P_8240_97"; private string _d_Material = "C245"; private string _d_AssyPref = ""; private string _d_AssyNo = ""; private string _d_PartPref = "д"; private string _d_PartNo = "1"; private string _d_Name = "ДИАФРАГМА"; private string _d_Class = "4";
        // Раскос рядовой
        private string _l_Profile = "L75X6_8509_93"; private string _l_Material = "C245"; private string _l_AssyPref = ""; private string _l_AssyNo = ""; private string _l_PartPref = "р"; private string _l_PartNo = "1"; private string _l_Name = "РАСКОС"; private string _l_Class = "3";
        // Раскос стыковой
        private string _ls_Profile = ""; private string _ls_Material = ""; private string _ls_AssyPref = ""; private string _ls_AssyNo = ""; private string _ls_PartPref = "рс"; private string _ls_PartNo = "1"; private string _ls_Name = "РАСКОС СТЫКОВОЙ"; private string _ls_Class = "3";
        // Распорка
        private string _s_Profile = ""; private string _s_Material = ""; private string _s_AssyPref = ""; private string _s_AssyNo = ""; private string _s_PartPref = "рп"; private string _s_PartNo = "1"; private string _s_Name = "РАСПОРКА"; private string _s_Class = "4";

        [StructuresDialog("Bcol", typeof(TD.Double))] public double Bcol { get => _bcol; set => Set(ref _bcol, value); }
        [StructuresDialog("Br_Rot", typeof(TD.Double))] public double Br_Rot { get => _br_Rot; set => Set(ref _br_Rot, value); }
        [StructuresDialog("Hcol_1", typeof(TD.Double))] public double Hcol_1 { get => _hcol_1; set => Set(ref _hcol_1, value); }
        [StructuresDialog("Hcol_e1", typeof(TD.Double))] public double Hcol_e1 { get => _hcol_e1; set => Set(ref _hcol_e1, value); }
        [StructuresDialog("Hcol_e2", typeof(TD.Double))] public double Hcol_e2 { get => _hcol_e2; set => Set(ref _hcol_e2, value); }
        [StructuresDialog("Hcol_e3", typeof(TD.Double))] public double Hcol_e3 { get => _hcol_e3; set => Set(ref _hcol_e3, value); }
        [StructuresDialog("SplicesText", typeof(TD.String))] public string SplicesText { get => _splicesText; set => Set(ref _splicesText, value); }
        [StructuresDialog("SpliceComponent", typeof(TD.String))] public string SpliceComponent { get => _spliceComponent; set => Set(ref _spliceComponent, value); }
        [StructuresDialog("SplicePreset", typeof(TD.String))] public string SplicePreset { get => _splicePreset; set => Set(ref _splicePreset, value); }

        [StructuresDialog("L_StepMode", typeof(TD.Integer))] public int L_StepMode { get => _l_StepMode; set => Set(ref _l_StepMode, value); }
        [StructuresDialog("Hr_base", typeof(TD.Double))] public double Hr_base { get => _hr_base; set => Set(ref _hr_base, value); }
        [StructuresDialog("L_StepText", typeof(TD.String))] public string L_StepText { get => _l_StepText; set => Set(ref _l_StepText, value); }
        [StructuresDialog("L_Rasc", typeof(TD.Double))] public double L_Rasc { get => _l_Rasc; set => Set(ref _l_Rasc, value); }
        [StructuresDialog("L_Rasc_Base", typeof(TD.Double))] public double L_Rasc_Base { get => _l_Rasc_Base; set => Set(ref _l_Rasc_Base, value); }
        [StructuresDialog("L_Rasc_Top", typeof(TD.Double))] public double L_Rasc_Top { get => _l_Rasc_Top; set => Set(ref _l_Rasc_Top, value); }
        [StructuresDialog("L_RascOverrides", typeof(TD.String))] public string L_RascOverrides { get => _l_RascOverrides; set => Set(ref _l_RascOverrides, value); }
        [StructuresDialog("L_Type", typeof(TD.Integer))] public int L_Type { get => _l_Type; set => Set(ref _l_Type, value); }
        [StructuresDialog("L_Preset", typeof(TD.Integer))] public int L_Preset { get => _l_Preset; set => Set(ref _l_Preset, value); }
        [StructuresDialog("L_Offset", typeof(TD.Double))] public double L_Offset { get => _l_Offset; set => Set(ref _l_Offset, value); }

        [StructuresDialog("S_Mode", typeof(TD.Integer))] public int S_Mode { get => _s_Mode; set => Set(ref _s_Mode, value); }
        [StructuresDialog("S_NodesDouble", typeof(TD.String))] public string S_NodesDouble { get => _s_NodesDouble; set => Set(ref _s_NodesDouble, value); }
        [StructuresDialog("S_NodesChannel", typeof(TD.String))] public string S_NodesChannel { get => _s_NodesChannel; set => Set(ref _s_NodesChannel, value); }
        [StructuresDialog("S_NodesExclude", typeof(TD.String))] public string S_NodesExclude { get => _s_NodesExclude; set => Set(ref _s_NodesExclude, value); }
        [StructuresDialog("S_Base_Preset", typeof(TD.Integer))] public int S_Base_Preset { get => _s_Base_Preset; set => Set(ref _s_Base_Preset, value); }
        [StructuresDialog("S_Top_Preset", typeof(TD.Integer))] public int S_Top_Preset { get => _s_Top_Preset; set => Set(ref _s_Top_Preset, value); }
        [StructuresDialog("S_Splice_Preset", typeof(TD.Integer))] public int S_Splice_Preset { get => _s_Splice_Preset; set => Set(ref _s_Splice_Preset, value); }
        [StructuresDialog("S_Preset", typeof(TD.Integer))] public int S_Preset { get => _s_Preset; set => Set(ref _s_Preset, value); }

        [StructuresDialog("B_Profile", typeof(TD.String))] public string B_Profile { get => _b_Profile; set => Set(ref _b_Profile, value); }
        [StructuresDialog("B_Material", typeof(TD.String))] public string B_Material { get => _b_Material; set => Set(ref _b_Material, value); }
        [StructuresDialog("B_AssyPref", typeof(TD.String))] public string B_AssyPref { get => _b_AssyPref; set => Set(ref _b_AssyPref, value); }
        [StructuresDialog("B_AssyNo", typeof(TD.String))] public string B_AssyNo { get => _b_AssyNo; set => Set(ref _b_AssyNo, value); }
        [StructuresDialog("B_PartPref", typeof(TD.String))] public string B_PartPref { get => _b_PartPref; set => Set(ref _b_PartPref, value); }
        [StructuresDialog("B_PartNo", typeof(TD.String))] public string B_PartNo { get => _b_PartNo; set => Set(ref _b_PartNo, value); }
        [StructuresDialog("B_Name", typeof(TD.String))] public string B_Name { get => _b_Name; set => Set(ref _b_Name, value); }
        [StructuresDialog("B_Class", typeof(TD.String))] public string B_Class { get => _b_Class; set => Set(ref _b_Class, value); }
        [StructuresDialog("D_Profile", typeof(TD.String))] public string D_Profile { get => _d_Profile; set => Set(ref _d_Profile, value); }
        [StructuresDialog("D_Material", typeof(TD.String))] public string D_Material { get => _d_Material; set => Set(ref _d_Material, value); }
        [StructuresDialog("D_AssyPref", typeof(TD.String))] public string D_AssyPref { get => _d_AssyPref; set => Set(ref _d_AssyPref, value); }
        [StructuresDialog("D_AssyNo", typeof(TD.String))] public string D_AssyNo { get => _d_AssyNo; set => Set(ref _d_AssyNo, value); }
        [StructuresDialog("D_PartPref", typeof(TD.String))] public string D_PartPref { get => _d_PartPref; set => Set(ref _d_PartPref, value); }
        [StructuresDialog("D_PartNo", typeof(TD.String))] public string D_PartNo { get => _d_PartNo; set => Set(ref _d_PartNo, value); }
        [StructuresDialog("D_Name", typeof(TD.String))] public string D_Name { get => _d_Name; set => Set(ref _d_Name, value); }
        [StructuresDialog("D_Class", typeof(TD.String))] public string D_Class { get => _d_Class; set => Set(ref _d_Class, value); }
        [StructuresDialog("L_Profile", typeof(TD.String))] public string L_Profile { get => _l_Profile; set => Set(ref _l_Profile, value); }
        [StructuresDialog("L_Material", typeof(TD.String))] public string L_Material { get => _l_Material; set => Set(ref _l_Material, value); }
        [StructuresDialog("L_AssyPref", typeof(TD.String))] public string L_AssyPref { get => _l_AssyPref; set => Set(ref _l_AssyPref, value); }
        [StructuresDialog("L_AssyNo", typeof(TD.String))] public string L_AssyNo { get => _l_AssyNo; set => Set(ref _l_AssyNo, value); }
        [StructuresDialog("L_PartPref", typeof(TD.String))] public string L_PartPref { get => _l_PartPref; set => Set(ref _l_PartPref, value); }
        [StructuresDialog("L_PartNo", typeof(TD.String))] public string L_PartNo { get => _l_PartNo; set => Set(ref _l_PartNo, value); }
        [StructuresDialog("L_Name", typeof(TD.String))] public string L_Name { get => _l_Name; set => Set(ref _l_Name, value); }
        [StructuresDialog("L_Class", typeof(TD.String))] public string L_Class { get => _l_Class; set => Set(ref _l_Class, value); }
        [StructuresDialog("LS_Profile", typeof(TD.String))] public string LS_Profile { get => _ls_Profile; set => Set(ref _ls_Profile, value); }
        [StructuresDialog("LS_Material", typeof(TD.String))] public string LS_Material { get => _ls_Material; set => Set(ref _ls_Material, value); }
        [StructuresDialog("LS_AssyPref", typeof(TD.String))] public string LS_AssyPref { get => _ls_AssyPref; set => Set(ref _ls_AssyPref, value); }
        [StructuresDialog("LS_AssyNo", typeof(TD.String))] public string LS_AssyNo { get => _ls_AssyNo; set => Set(ref _ls_AssyNo, value); }
        [StructuresDialog("LS_PartPref", typeof(TD.String))] public string LS_PartPref { get => _ls_PartPref; set => Set(ref _ls_PartPref, value); }
        [StructuresDialog("LS_PartNo", typeof(TD.String))] public string LS_PartNo { get => _ls_PartNo; set => Set(ref _ls_PartNo, value); }
        [StructuresDialog("LS_Name", typeof(TD.String))] public string LS_Name { get => _ls_Name; set => Set(ref _ls_Name, value); }
        [StructuresDialog("LS_Class", typeof(TD.String))] public string LS_Class { get => _ls_Class; set => Set(ref _ls_Class, value); }
        [StructuresDialog("S_Profile", typeof(TD.String))] public string S_Profile { get => _s_Profile; set => Set(ref _s_Profile, value); }
        [StructuresDialog("S_Material", typeof(TD.String))] public string S_Material { get => _s_Material; set => Set(ref _s_Material, value); }
        [StructuresDialog("S_AssyPref", typeof(TD.String))] public string S_AssyPref { get => _s_AssyPref; set => Set(ref _s_AssyPref, value); }
        [StructuresDialog("S_AssyNo", typeof(TD.String))] public string S_AssyNo { get => _s_AssyNo; set => Set(ref _s_AssyNo, value); }
        [StructuresDialog("S_PartPref", typeof(TD.String))] public string S_PartPref { get => _s_PartPref; set => Set(ref _s_PartPref, value); }
        [StructuresDialog("S_PartNo", typeof(TD.String))] public string S_PartNo { get => _s_PartNo; set => Set(ref _s_PartNo, value); }
        [StructuresDialog("S_Name", typeof(TD.String))] public string S_Name { get => _s_Name; set => Set(ref _s_Name, value); }
        [StructuresDialog("S_Class", typeof(TD.String))] public string S_Class { get => _s_Class; set => Set(ref _s_Class, value); }
    }
}