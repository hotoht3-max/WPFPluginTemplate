using System.Windows;
using System.Windows.Controls;

namespace Apibim.Plugins.BuiltUpColumn.UIControls
{
    public partial class UdaLauncherControl : UserControl
    {
        public static readonly DependencyProperty ButtonTextProperty = DependencyProperty.Register("ButtonText", typeof(string), typeof(UdaLauncherControl), new PropertyMetadata("Пользовательские атрибуты..."));
        public string ButtonText { get { return (string)GetValue(ButtonTextProperty); } set { SetValue(ButtonTextProperty, value); } }

        public UdaLauncherControl()
        {
            InitializeComponent();
        }

        private void UdaButton_Click(object sender, RoutedEventArgs e)
        {
            // Здесь в будущем будет вызов полноценного окна WindowUda.xaml
            MessageBox.Show("Здесь будет окно редактирования Пользовательских атрибутов (UDA).", "RAM BIM", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}