using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
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

        // --- УНИВЕРСАЛЬНЫЙ ВЫЗОВ КАТАЛОГА ПРОФИЛЕЙ (Событийный подход WPF) ---
        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag != null)
            {
                string propName = btn.Tag.ToString();
                PropertyInfo prop = typeof(MainWindowViewModel).GetProperty(propName);

                if (prop != null)
                {
                    var catalog = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
                    catalog.SelectedProfile = (string)prop.GetValue(DataViewModel) ?? string.Empty;

                    // Подписываемся на событие выбора профиля (Дабл-клик или кнопка ОК)
                    catalog.SelectClicked += (s, args) =>
                    {
                        prop.SetValue(DataViewModel, catalog.SelectedProfile);
                    };

                    catalog.Show(); // Метод без аргументов, возвращает void
                }
            }
        }

        // --- УНИВЕРСАЛЬНЫЙ ВЫЗОВ КАТАЛОГА МАТЕРИАЛОВ ---
        private void BtnMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag != null)
            {
                string propName = btn.Tag.ToString();
                PropertyInfo prop = typeof(MainWindowViewModel).GetProperty(propName);

                if (prop != null)
                {
                    var catalog = new Tekla.Structures.Dialog.UIControls.MaterialCatalog();
                    catalog.SelectedMaterial = (string)prop.GetValue(DataViewModel) ?? string.Empty;

                    catalog.SelectClicked += (s, args) =>
                    {
                        prop.SetValue(DataViewModel, catalog.SelectedMaterial);
                    };

                    catalog.Show();
                }
            }
        }

        // --- ВЫЗОВ КАТАЛОГА КОМПОНЕНТОВ ---
        private void BtnComponent_Click(object sender, RoutedEventArgs e)
        {
            var catalog = new Tekla.Structures.Dialog.UIControls.ComponentCatalog();
            catalog.SelectedName = DataViewModel.SpliceComponent ?? string.Empty;

            catalog.SelectClicked += (s, args) =>
            {
                DataViewModel.SpliceComponent = catalog.SelectedName;
            };

            catalog.Show();
        }

        // --- ВЫЗОВ ПРЕСЕТОВ СТЫКА (Подготовка к ComboBox) ---
        private void BtnPreset_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Окно 'Список файлов атрибутов' (из старого API) недоступно в текущей WPF-библиотеке.\n\nНа следующем шаге мы заменим это поле на нативный ComboBox и научим его читать файлы атрибутов для выбранного компонента.", "RAM BIM", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // --- СТАНДАРТНЫЕ КНОПКИ TEKLA ---
        private void WpfOkApplyModifyGetOnOffCancel_ApplyClicked(object sender, EventArgs e) => this.Apply();
        private void WpfOkApplyModifyGetOnOffCancel_CancelClicked(object sender, EventArgs e) => this.Close();
        private void WpfOkApplyModifyGetOnOffCancel_GetClicked(object sender, EventArgs e) => this.Get();
        private void WpfOkApplyModifyGetOnOffCancel_ModifyClicked(object sender, EventArgs e) => this.Modify();
        private void WpfOkApplyModifyGetOnOffCancel_OkClicked(object sender, EventArgs e) { this.Apply(); this.Close(); }
        private void WpfOkApplyModifyGetOnOffCancel_OnOffClicked(object sender, EventArgs e) => this.ToggleSelection();
    }
}