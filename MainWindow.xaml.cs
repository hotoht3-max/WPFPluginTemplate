using System;
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

        // --- ОБРАБОТЧИКИ КАТАЛОГОВ (Встроенная логика Tekla WPF) ---

        private void BranchProfileCatalog_SelectClicked(object sender, EventArgs e)
        {
            this.BranchProfileCatalog.SelectedProfile = this.DataViewModel.BranchProfile;
        }
        private void BranchProfileCatalog_SelectionDone(object sender, EventArgs e)
        {
            this.DataViewModel.BranchProfile = this.BranchProfileCatalog.SelectedProfile;
        }

        private void LacingProfileCatalog_SelectClicked(object sender, EventArgs e)
        {
            this.LacingProfileCatalog.SelectedProfile = this.DataViewModel.LacingProfile;
        }
        private void LacingProfileCatalog_SelectionDone(object sender, EventArgs e)
        {
            this.DataViewModel.LacingProfile = this.LacingProfileCatalog.SelectedProfile;
        }

        private void MaterialCatalog_SelectClicked(object sender, EventArgs e)
        {
            this.MaterialCatalog.SelectedMaterial = this.DataViewModel.Material;
        }
        private void MaterialCatalog_SelectionDone(object sender, EventArgs e)
        {
            this.DataViewModel.Material = this.MaterialCatalog.SelectedMaterial;
        }

        // --- СТАНДАРТНЫЕ ОБРАБОТЧИКИ КНОПОК ---
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
        private void StrutProfileCatalog_SelectClicked(object sender, EventArgs e)
        {
            this.StrutProfileCatalog.SelectedProfile = this.DataViewModel.S_Profile;
        }
        private void StrutProfileCatalog_SelectionDone(object sender, EventArgs e)
        {
            this.DataViewModel.S_Profile = this.StrutProfileCatalog.SelectedProfile;
        }

        private void StrutMaterialCatalog_SelectClicked(object sender, EventArgs e)
        {
            this.StrutMaterialCatalog.SelectedMaterial = this.DataViewModel.S_Material;
        }
        private void StrutMaterialCatalog_SelectionDone(object sender, EventArgs e)
        {
            this.DataViewModel.S_Material = this.StrutMaterialCatalog.SelectedMaterial;
        }
    }
}