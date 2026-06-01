using Tekla.Structures.Dialog;
using WPFPluginTemplate;
using TD = Tekla.Structures.Datatype;

namespace Apibim.Plugins.BuiltUpColumn
{
    public class MainWindowViewModel : BaseViewModel
    {
        private double _hcol_1 = 10000.0;
        private double _hcol_e1 = 500.0;
        private double _hcol_e2 = 600.0;
        private double _hcol_e3 = 600.0;
        private double _hr_base = 1200.0;

        private string _branchProfile = "I20K1_57837_2017";
        private string _lacingProfile = "L75X6_8509_93";
        private string _material = "C355Б";

        [StructuresDialog("Hcol_1", typeof(TD.Double))]
        public double Hcol_1 { get => _hcol_1; set => Set(ref _hcol_1, value); }

        [StructuresDialog("Hcol_e1", typeof(TD.Double))]
        public double Hcol_e1 { get => _hcol_e1; set => Set(ref _hcol_e1, value); }

        [StructuresDialog("Hcol_e2", typeof(TD.Double))]
        public double Hcol_e2 { get => _hcol_e2; set => Set(ref _hcol_e2, value); }

        [StructuresDialog("Hcol_e3", typeof(TD.Double))]
        public double Hcol_e3 { get => _hcol_e3; set => Set(ref _hcol_e3, value); }

        [StructuresDialog("Hr_base", typeof(TD.Double))]
        public double Hr_base { get => _hr_base; set => Set(ref _hr_base, value); }

        [StructuresDialog("BranchProfile", typeof(TD.String))]
        public string BranchProfile { get => _branchProfile; set => Set(ref _branchProfile, value); }

        [StructuresDialog("LacingProfile", typeof(TD.String))]
        public string LacingProfile { get => _lacingProfile; set => Set(ref _lacingProfile, value); }

        [StructuresDialog("Material", typeof(TD.String))]
        public string Material { get => _material; set => Set(ref _material, value); }
    }
}