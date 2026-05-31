using Tekla.Structures.Dialog;
using WPFPluginTemplate;
using TD = Tekla.Structures.Datatype;

namespace Apibim.Tekla.Plugins.BuiltUpColumn
{
    public class MainWindowViewModel : BaseViewModel
    {
        [StructuresDialog("TopExtension", typeof(TD.Double))]
        public double TopExtension { get; set; } = 10000.0;

        [StructuresDialog("BottomExtension", typeof(TD.Double))]
        public double BottomExtension { get; set; } = 500.0;

        [StructuresDialog("LacingBottomClearance", typeof(TD.Double))]
        public double LacingBottomClearance { get; set; } = 600.0;

        [StructuresDialog("LacingTopClearance", typeof(TD.Double))]
        public double LacingTopClearance { get; set; } = 600.0;

        [StructuresDialog("TargetLacingStep", typeof(TD.Double))]
        public double TargetLacingStep { get; set; } = 1200.0;

        [StructuresDialog("BranchProfile", typeof(TD.String))]
        public string BranchProfile { get; set; } = "I20K1_57837_2017";

        [StructuresDialog("LacingProfile", typeof(TD.String))]
        public string LacingProfile { get; set; } = "L50X4_8509_93";

        [StructuresDialog("Material", typeof(TD.String))]
        public string Material { get; set; } = "C355Б";
    }
}