using System.Windows;
using System.Windows.Controls;

namespace Apibim.Plugins.BuiltUpColumn.UIControls
{
    public partial class MacroTextRowControl : UserControl
    {
        public MacroTextRowControl()
        {
            InitializeComponent();
        }

        public string AttributeName
        {
            get { return (string)GetValue(AttributeNameProperty); }
            set { SetValue(AttributeNameProperty, value); }
        }

        // Регистрируем Callback, который сработает при изменении значения
        public static readonly DependencyProperty AttributeNameProperty =
            DependencyProperty.Register("AttributeName", typeof(string), typeof(MacroTextRowControl),
                new PropertyMetadata(string.Empty, OnAttributeNameChanged));

        private static void OnAttributeNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MacroTextRowControl control && e.NewValue is string newName)
            {
                // Напрямую передаем имя в текловский компонент
                if (control.filterCb != null)
                {
                    control.filterCb.AttributeName = newName;
                }
            }
        }

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(MacroTextRowControl), new PropertyMetadata(string.Empty));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MacroTextRowControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}