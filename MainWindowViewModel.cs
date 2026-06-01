using Tekla.Structures.Dialog;
using WPFPluginTemplate;
using TD = Tekla.Structures.Datatype;

namespace Apibim.Plugins.BuiltUpColumn
{
    public class MainWindowViewModel : BaseViewModel
    {
        private double _bcol = 500.0;
        private double _br_Rot = 90.0;
        private double _hcol_1 = 10000.0;
        private double _hcol_e1 = 500.0;
        private double _hcol_e2 = 600.0;
        private double _hcol_e3 = 600.0;

        private double _hr_base = 1200.0;
        private double _l_Rasc = 50.0;
        private int _l_Type = 1;
        private int _l_Preset = 1;
        private double _l_Offset = 0.0;

        private int _s_Preset = 1;

        private string _branchProfile = "I20K1_57837_2017";
        private string _lacingProfile = "L75X6_8509_93";
        private string _s_Profile = "16P_8240_97";
        private string _material = "C355Б";
        private string _s_Material = "C245";

        [StructuresDialog("Bcol", typeof(TD.Double))] public double Bcol { get => _bcol; set => Set(ref _bcol, value); }
        [StructuresDialog("Br_Rot", typeof(TD.Double))] public double Br_Rot { get => _br_Rot; set => Set(ref _br_Rot, value); }
        [StructuresDialog("Hcol_1", typeof(TD.Double))] public double Hcol_1 { get => _hcol_1; set => Set(ref _hcol_1, value); }
        [StructuresDialog("Hcol_e1", typeof(TD.Double))] public double Hcol_e1 { get => _hcol_e1; set => Set(ref _hcol_e1, value); }
        [StructuresDialog("Hcol_e2", typeof(TD.Double))] public double Hcol_e2 { get => _hcol_e2; set => Set(ref _hcol_e2, value); }
        [StructuresDialog("Hcol_e3", typeof(TD.Double))] public double Hcol_e3 { get => _hcol_e3; set => Set(ref _hcol_e3, value); }

        [StructuresDialog("Hr_base", typeof(TD.Double))] public double Hr_base { get => _hr_base; set => Set(ref _hr_base, value); }
        [StructuresDialog("L_Rasc", typeof(TD.Double))] public double L_Rasc { get => _l_Rasc; set => Set(ref _l_Rasc, value); }
        [StructuresDialog("L_Type", typeof(TD.Integer))] public int L_Type { get => _l_Type; set => Set(ref _l_Type, value); }
        [StructuresDialog("L_Preset", typeof(TD.Integer))] public int L_Preset { get => _l_Preset; set => Set(ref _l_Preset, value); }
        [StructuresDialog("L_Offset", typeof(TD.Double))] public double L_Offset { get => _l_Offset; set => Set(ref _l_Offset, value); }

        [StructuresDialog("S_Preset", typeof(TD.Integer))] public int S_Preset { get => _s_Preset; set => Set(ref _s_Preset, value); }

        [StructuresDialog("BranchProfile", typeof(TD.String))] public string BranchProfile { get => _branchProfile; set => Set(ref _branchProfile, value); }
        [StructuresDialog("LacingProfile", typeof(TD.String))] public string LacingProfile { get => _lacingProfile; set => Set(ref _lacingProfile, value); }
        [StructuresDialog("S_Profile", typeof(TD.String))] public string S_Profile { get => _s_Profile; set => Set(ref _s_Profile, value); }
        [StructuresDialog("Material", typeof(TD.String))] public string Material { get => _material; set => Set(ref _material, value); }
        [StructuresDialog("S_Material", typeof(TD.String))] public string S_Material { get => _s_Material; set => Set(ref _s_Material, value); }
    }
}