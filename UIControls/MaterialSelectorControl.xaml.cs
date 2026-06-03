using System;
using System.Windows;
using System.Windows.Controls;

namespace Apibim.Plugins.BuiltUpColumn.UIControls
{
    public partial class MaterialSelectorControl : UserControl
    {
        // Свойство для текста слева (Label)
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(MaterialSelectorControl), new PropertyMetadata("Материал:"));

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        // Свойство для двусторонней привязки переменной материала
        public static readonly DependencyProperty BoundTextProperty =
            DependencyProperty.Register("BoundText", typeof(string), typeof(MaterialSelectorControl),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string BoundText
        {
            get { return (string)GetValue(BoundTextProperty); }
            set { SetValue(BoundTextProperty, value); }
        }

        public MaterialSelectorControl()
        {
            InitializeComponent();
        }

        // --- Инкапсулированная логика каталога Tekla ---

        private void MaterialCatalog_SelectClicked(object sender, EventArgs e)
        {
            // Передаем текущий текст в каталог перед его открытием
            MaterialCatalog.SelectedMaterial = BoundText;
        }

        private void MaterialCatalog_SelectionDone(object sender, EventArgs e)
        {
            // Забираем выбранный материал из каталога в наше свойство
            BoundText = MaterialCatalog.SelectedMaterial;
        }
    }
}