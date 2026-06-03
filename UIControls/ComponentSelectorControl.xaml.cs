using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Apibim.Plugins.BuiltUpColumn.UIControls
{
    public partial class ComponentSelectorControl : UserControl
    {
        public static readonly DependencyProperty ComponentLabelProperty = DependencyProperty.Register("ComponentLabel", typeof(string), typeof(ComponentSelectorControl), new PropertyMetadata("Компонент:"));
        public string ComponentLabel { get { return (string)GetValue(ComponentLabelProperty); } set { SetValue(ComponentLabelProperty, value); } }

        public static readonly DependencyProperty ComponentTextProperty = DependencyProperty.Register("ComponentText", typeof(string), typeof(ComponentSelectorControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string ComponentText { get { return (string)GetValue(ComponentTextProperty); } set { SetValue(ComponentTextProperty, value); } }

        public static readonly DependencyProperty PresetLabelProperty = DependencyProperty.Register("PresetLabel", typeof(string), typeof(ComponentSelectorControl), new PropertyMetadata("Пресет:"));
        public string PresetLabel { get { return (string)GetValue(PresetLabelProperty); } set { SetValue(PresetLabelProperty, value); } }

        public static readonly DependencyProperty PresetTextProperty = DependencyProperty.Register("PresetText", typeof(string), typeof(ComponentSelectorControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string PresetText { get { return (string)GetValue(PresetTextProperty); } set { SetValue(PresetTextProperty, value); } }

        public ComponentSelectorControl()
        {
            InitializeComponent();
        }

        private void ComponentCatalog_SelectClicked(object sender, EventArgs e)
        {
            ComponentCatalog.SelectedName = ComponentText;
        }

        private void ComponentCatalog_SelectionDone(object sender, EventArgs e)
        {
            string compName = ComponentCatalog.SelectedName;
            int compNumber = ComponentCatalog.SelectedNumber;
            ComponentText = !string.IsNullOrEmpty(compName) ? compName : compNumber.ToString();
        }

        private void PresetButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ComponentText))
            {
                MessageBox.Show("Сначала укажите компонент!", "RAM BIM", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var attributes = new List<string>();
                if (int.TryParse(ComponentText, out int compNumber))
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
                        var files = Tekla.Structures.Dialog.UIControls.EnvironmentFiles.GetAttributeFiles(p + ComponentText);
                        if (files != null) attributes.AddRange(files);
                    }
                }

                var cleanNames = new List<string>();
                foreach (var f in attributes)
                {
                    string clean = Path.GetFileNameWithoutExtension(f);
                    if (!string.IsNullOrEmpty(clean) && !cleanNames.Contains(clean)) cleanNames.Add(clean);
                }

                if (cleanNames.Count == 0)
                {
                    MessageBox.Show($"Для компонента '{ComponentText}' нет сохраненных пресетов.", "RAM BIM", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                ShowPresetDialog(cleanNames);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "RAM BIM", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowPresetDialog(List<string> cleanNames)
        {
            var window = new Window { Title = "Выбор пресета", Width = 300, Height = 400, WindowStartupLocation = WindowStartupLocation.CenterScreen, Topmost = true, ResizeMode = ResizeMode.NoResize };
            var grid = new Grid();
            var listBox = new ListBox { ItemsSource = cleanNames, Margin = new Thickness(10) };

            if (!string.IsNullOrWhiteSpace(PresetText) && cleanNames.Contains(PresetText))
                listBox.SelectedItem = PresetText;

            listBox.MouseDoubleClick += (s, args) =>
            {
                if (listBox.SelectedItem != null)
                {
                    PresetText = listBox.SelectedItem.ToString();
                    window.Close();
                }
            };

            grid.Children.Add(listBox);
            window.Content = grid;
            window.ShowDialog();
        }
    }
}