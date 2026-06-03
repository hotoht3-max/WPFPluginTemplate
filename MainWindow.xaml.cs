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

        // --- 1. МАТЕРИАЛ ---
        private void TestMaterialCat_SelectClicked(object sender, EventArgs e)
        {
            // Берем текущий текст из поля и передаем в каталог
            TestMaterialCat.SelectedMaterial = TxtTestMaterial.Text;
        }

        private void TestMaterialCat_SelectionDone(object sender, EventArgs e)
        {
            // Записываем выбор обратно в поле ввода
            TxtTestMaterial.Text = TestMaterialCat.SelectedMaterial;
        }

        // --- 2. ПРОФИЛЬ ---
        private void TestProfileCat_SelectClicked(object sender, EventArgs e)
        {
            TestProfileCat.SelectedProfile = TxtTestProfile.Text;
        }

        private void TestProfileCat_SelectionDone(object sender, EventArgs e)
        {
            TxtTestProfile.Text = TestProfileCat.SelectedProfile;
        }

        // --- 3. КОМПОНЕНТ ---
        private void TestComponentCat_SelectClicked(object sender, EventArgs e)
        {
            TestComponentCat.SelectedName = TxtTestComponent.Text;
        }

        private void TestComponentCat_SelectionDone(object sender, EventArgs e)
        {
            string compName = TestComponentCat.SelectedName;
            int compNumber = TestComponentCat.SelectedNumber;
            // Учитываем разницу между системными (номер) и кастомными (имя)
            TxtTestComponent.Text = !string.IsNullOrEmpty(compName) ? compName : compNumber.ToString();
        }

        // --- 4. ПРЕСЕТ (Отдельное окно) ---
        private void TestPreset_Click(object sender, RoutedEventArgs e)
        {
            string componentValue = TxtTestComponent.Text;

            if (string.IsNullOrWhiteSpace(componentValue))
            {
                MessageBox.Show("Сначала укажите компонент!", "RAM BIM Тест", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var attributes = new System.Collections.Generic.List<string>();

                // Логика поиска файлов (учитывает и системные, и кастомные префиксы)
                if (int.TryParse(componentValue, out int compNumber))
                {
                    string[] prefixes = { ".j", ".d", ".p", ".s" };
                    foreach (string p in prefixes)
                    {
                        var files = Tekla.Structures.Dialog.UIControls.EnvironmentFiles.GetAttributeFiles(p + compNumber);
                        if (files != null) attributes.AddRange(files);
                    }
                }
                else
                {
                    string[] prefixes = { ".", ".j_", ".d_", ".p_", ".s_" };
                    foreach (string p in prefixes)
                    {
                        var files = Tekla.Structures.Dialog.UIControls.EnvironmentFiles.GetAttributeFiles(p + componentValue);
                        if (files != null) attributes.AddRange(files);
                    }
                }

                var cleanNames = new System.Collections.Generic.List<string>();
                foreach (var f in attributes)
                {
                    string clean = System.IO.Path.GetFileNameWithoutExtension(f);
                    if (!string.IsNullOrEmpty(clean) && !cleanNames.Contains(clean)) cleanNames.Add(clean);
                }

                if (cleanNames.Count == 0)
                {
                    MessageBox.Show($"Для компонента '{componentValue}' нет сохраненных пресетов в модели.", "RAM BIM Тест", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Создаем диалоговое окно WPF
                var window = new System.Windows.Window
                {
                    Title = "Пресеты",
                    Width = 300,
                    Height = 400,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                    Topmost = true,
                    ResizeMode = ResizeMode.NoResize
                };

                var grid = new System.Windows.Controls.Grid();
                grid.RowDefinitions.Add(new System.Windows.Controls.RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                var listBox = new System.Windows.Controls.ListBox { ItemsSource = cleanNames, Margin = new Thickness(10) };

                // Если в поле ввода уже есть текст, пытаемся выделить его в списке
                if (!string.IsNullOrWhiteSpace(TxtTestPreset.Text) && cleanNames.Contains(TxtTestPreset.Text))
                {
                    listBox.SelectedItem = TxtTestPreset.Text;
                }

                System.Windows.Controls.Grid.SetRow(listBox, 0);

                listBox.MouseDoubleClick += (s, args) =>
                {
                    if (listBox.SelectedItem != null)
                    {
                        // Записываем обратно в поле
                        TxtTestPreset.Text = listBox.SelectedItem.ToString();
                        window.Close();
                    }
                };

                grid.Children.Add(listBox);
                window.Content = grid;
                window.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "RAM BIM Тест", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // --- ЗАГЛУШКИ ДЛЯ СОБЫТИЙ КАТАЛОГОВ ИЗ XAML (ДЛЯ УСПЕШНОЙ КОМПИЛЯЦИИ) ---
        private void B_ProfileCat_SelectClicked(object sender, EventArgs e) { }
        private void B_ProfileCat_SelectionDone(object sender, EventArgs e) { }

        private void B_MaterialCat_SelectClicked(object sender, EventArgs e) { }
        private void B_MaterialCat_SelectionDone(object sender, EventArgs e) { }

        private void D_ProfileCat_SelectClicked(object sender, EventArgs e) { }
        private void D_ProfileCat_SelectionDone(object sender, EventArgs e) { }

        private void D_MaterialCat_SelectClicked(object sender, EventArgs e) { }
        private void D_MaterialCat_SelectionDone(object sender, EventArgs e) { }

        private void L_ProfileCat_SelectClicked(object sender, EventArgs e) { }
        private void L_ProfileCat_SelectionDone(object sender, EventArgs e) { }

        private void L_MaterialCat_SelectClicked(object sender, EventArgs e) { }
        private void L_MaterialCat_SelectionDone(object sender, EventArgs e) { }

        private void LS_ProfileCat_SelectClicked(object sender, EventArgs e) { }
        private void LS_ProfileCat_SelectionDone(object sender, EventArgs e) { }

        private void LS_MaterialCat_SelectClicked(object sender, EventArgs e) { }
        private void LS_MaterialCat_SelectionDone(object sender, EventArgs e) { }

        private void S_ProfileCat_SelectClicked(object sender, EventArgs e) { }
        private void S_ProfileCat_SelectionDone(object sender, EventArgs e) { }

        private void S_MaterialCat_SelectClicked(object sender, EventArgs e) { }
        private void S_MaterialCat_SelectionDone(object sender, EventArgs e) { }
    }
}