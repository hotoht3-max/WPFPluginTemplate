using Tekla.Structures.Dialog;
using WPFPluginTemplate;
using TD = Tekla.Structures.Datatype;

namespace Apibim.Plugins.BuiltUpColumn
{
    public class MainWindowViewModel : BaseViewModel
    {
        // Общее
        private double _bcol = 500.0;
        private double _br_Rot = 90.0;
        private double _hcol_1 = 10000.0;
        private double _hcol_e1 = 500.0;
        private double _hcol_e2 = 600.0;
        private double _hcol_e3 = 600.0;
        private string _splicesText = "";
        private string _branchProfile = "I20K1_57837_2017";
        private string _material = "C355Б";

        // Решетка
        private int _l_StepMode = 0;
        private double _hr_base = 1200.0;
        private string _l_StepText = "";

        private double _l_Rasc = 50.0;
        private double _l_Rasc_Base = 50.0;
        private double _l_Rasc_Top = 50.0;
        private string _l_RascOverrides = "";

        private int _l_Type = 1;
        private int _l_Preset = 1;
        private double _l_Offset = 0.0;
        private string _lacingProfile = "L75X6_8509_93";

        // Планки
        private int _s_Mode = 0;
        private string _s_NodesDouble = "";
        private string _s_NodesChannel = "";
        private string _s_NodesExclude = "";

        private int _s_Base_Preset = 2;   // Диафрагма
        private int _s_Top_Preset = 2;    // Диафрагма
        private int _s_Splice_Preset = 2; // Диафрагма
        private int _s_Preset = 1;        // Распорка

        private string _s_Profile = "L75X6_8509_93";
        private string _s_Material = "C245";
        private string _d_Profile = "16P_8240_97";
        private string _d_Material = "C245";

        // --- Биндинги ---
        [StructuresDialog("Bcol", typeof(TD.Double))] public double Bcol { get => _bcol; set => Set(ref _bcol, value); }
        [StructuresDialog("Br_Rot", typeof(TD.Double))] public double Br_Rot { get => _br_Rot; set => Set(ref _br_Rot, value); }
        [StructuresDialog("Hcol_1", typeof(TD.Double))] public double Hcol_1 { get => _hcol_1; set => Set(ref _hcol_1, value); }
        [StructuresDialog("Hcol_e1", typeof(TD.Double))] public double Hcol_e1 { get => _hcol_e1; set => Set(ref _hcol_e1, value); }
        [StructuresDialog("Hcol_e2", typeof(TD.Double))] public double Hcol_e2 { get => _hcol_e2; set => Set(ref _hcol_e2, value); }
        [StructuresDialog("Hcol_e3", typeof(TD.Double))] public double Hcol_e3 { get => _hcol_e3; set => Set(ref _hcol_e3, value); }

        [StructuresDialog("SplicesText", typeof(TD.String))] public string SplicesText { get => _splicesText; set => Set(ref _splicesText, value); }
        [StructuresDialog("BranchProfile", typeof(TD.String))] public string BranchProfile { get => _branchProfile; set => Set(ref _branchProfile, value); }
        [StructuresDialog("Material", typeof(TD.String))] public string Material { get => _material; set => Set(ref _material, value); }

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
        [StructuresDialog("LacingProfile", typeof(TD.String))] public string LacingProfile { get => _lacingProfile; set => Set(ref _lacingProfile, value); }

        [StructuresDialog("S_Mode", typeof(TD.Integer))] public int S_Mode { get => _s_Mode; set => Set(ref _s_Mode, value); }
        [StructuresDialog("S_NodesDouble", typeof(TD.String))] public string S_NodesDouble { get => _s_NodesDouble; set => Set(ref _s_NodesDouble, value); }
        [StructuresDialog("S_NodesChannel", typeof(TD.String))] public string S_NodesChannel { get => _s_NodesChannel; set => Set(ref _s_NodesChannel, value); }
        [StructuresDialog("S_NodesExclude", typeof(TD.String))] public string S_NodesExclude { get => _s_NodesExclude; set => Set(ref _s_NodesExclude, value); }

        [StructuresDialog("S_Base_Preset", typeof(TD.Integer))] public int S_Base_Preset { get => _s_Base_Preset; set => Set(ref _s_Base_Preset, value); }
        [StructuresDialog("S_Top_Preset", typeof(TD.Integer))] public int S_Top_Preset { get => _s_Top_Preset; set => Set(ref _s_Top_Preset, value); }
        [StructuresDialog("S_Splice_Preset", typeof(TD.Integer))] public int S_Splice_Preset { get => _s_Splice_Preset; set => Set(ref _s_Splice_Preset, value); }
        [StructuresDialog("S_Preset", typeof(TD.Integer))] public int S_Preset { get => _s_Preset; set => Set(ref _s_Preset, value); }

        [StructuresDialog("S_Profile", typeof(TD.String))] public string S_Profile { get => _s_Profile; set => Set(ref _s_Profile, value); }
        [StructuresDialog("S_Material", typeof(TD.String))] public string S_Material { get => _s_Material; set => Set(ref _s_Material, value); }
        [StructuresDialog("D_Profile", typeof(TD.String))] public string D_Profile { get => _d_Profile; set => Set(ref _d_Profile, value); }
        [StructuresDialog("D_Material", typeof(TD.String))] public string D_Material { get => _d_Material; set => Set(ref _d_Material, value); }
    }
}