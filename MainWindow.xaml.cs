using System;
using System.Windows;
using Tekla.Structures.Dialog;

namespace Apibim.Plugins.BuiltUpColumn
{
    public partial class MainWindow : PluginWindowBase
    {
        public MainWindowViewModel DataViewModel { get; set; }

        public MainWindow(MainWindowViewModel ViewModel)
        {
            InitializeComponent();
            DataViewModel = ViewModel;
            this.DataContext = DataViewModel;
        }

        // ==========================================
        // ВСЯ ЛОГИКА ТЕПЕРЬ ВНУТРИ UIControls! 
        // Здесь остались только стандартные кнопки окна.
        // ==========================================

        private void WpfOkApplyModifyGetOnOffCancel_ApplyClicked(object sender, EventArgs e) => this.Apply();
        private void WpfOkApplyModifyGetOnOffCancel_CancelClicked(object sender, EventArgs e) => this.Close();
        private void WpfOkApplyModifyGetOnOffCancel_GetClicked(object sender, EventArgs e) => this.Get();
        private void WpfOkApplyModifyGetOnOffCancel_ModifyClicked(object sender, EventArgs e) => this.Modify();
        private void WpfOkApplyModifyGetOnOffCancel_OkClicked(object sender, EventArgs e)
        {
            this.Apply();
            this.Close();
        }
        private void WpfOkApplyModifyGetOnOffCancel_OnOffClicked(object sender, EventArgs e) => this.ToggleSelection();
    }
}