using System.Windows;
using System.Windows.Controls;

namespace Apibim.Plugins.BuiltUpColumn.UIControls
{
    public partial class DiaphragmPositioningControl : UserControl
    {
        public DiaphragmPositioningControl()
        {
            InitializeComponent();
        }

        private void PosMasterChk_Click(object sender, RoutedEventArgs e)
        {
            bool isChecked = PosMasterChk.IsChecked == true;
            if (PosRowD1 != null) PosRowD1.ToggleAll(isChecked);
            if (PosRowD2 != null) PosRowD2.ToggleAll(isChecked);
        }
    }
}