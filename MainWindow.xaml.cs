using System;
using Tekla.Structures.Dialog;

namespace Apibim.Tekla.Plugins.BuiltUpColumn
{
    public partial class MainWindow : PluginWindowBase
    {
        public MainWindowViewModel dataViewModel { get; set; }

        public MainWindow(MainWindowViewModel ViewModel)
        {
            InitializeComponent();
            dataViewModel = ViewModel;
        }

        // --- Стандартные обработчики нижних кнопок Tekla ---

        private void WpfOkApplyModifyGetOnOffCancel_ApplyClicked(object sender, EventArgs e)
        {
            this.Apply();
        }

        private void WpfOkApplyModifyGetOnOffCancel_CancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WpfOkApplyModifyGetOnOffCancel_GetClicked(object sender, EventArgs e)
        {
            this.Get();
        }

        private void WpfOkApplyModifyGetOnOffCancel_ModifyClicked(object sender, EventArgs e)
        {
            this.Modify();
        }

        private void WpfOkApplyModifyGetOnOffCancel_OkClicked(object sender, EventArgs e)
        {
            this.SaveValues();
            this.Apply();
            this.Close();
        }

        private void WpfOkApplyModifyGetOnOffCancel_OnOffClicked(object sender, EventArgs e)
        {
            this.ToggleSelection();
        }
    }
}