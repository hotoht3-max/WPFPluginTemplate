using System.Windows;
using System.Windows.Controls;

namespace Apibim.Plugins.BuiltUpColumn.UIControls
{
    public partial class HeadBeamControl : UserControl
    {
        public HeadBeamControl()
        {
            InitializeComponent();
        }

        private void PosMasterChk_Click(object sender, RoutedEventArgs e)
        {
            // Эта логика связывает главную галочку с внутренними галочками контрола
            bool isChecked = PosMasterChk.IsChecked == true;
            if (PosRowHB != null) PosRowHB.ToggleAll(isChecked);
        }
    }
}