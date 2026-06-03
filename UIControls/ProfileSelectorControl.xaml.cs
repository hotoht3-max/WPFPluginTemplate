using System;
using System.Windows;
using System.Windows.Controls;

namespace Apibim.Plugins.BuiltUpColumn.UIControls
{
    public partial class ProfileSelectorControl : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(ProfileSelectorControl), new PropertyMetadata("Профиль:"));

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly DependencyProperty BoundTextProperty =
            DependencyProperty.Register("BoundText", typeof(string), typeof(ProfileSelectorControl),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string BoundText
        {
            get { return (string)GetValue(BoundTextProperty); }
            set { SetValue(BoundTextProperty, value); }
        }

        public ProfileSelectorControl()
        {
            InitializeComponent();
        }

        // --- Инкапсулированная логика каталога ПРОФИЛЕЙ ---

        private void ProfileCatalog_SelectClicked(object sender, EventArgs e)
        {
            ProfileCatalog.SelectedProfile = BoundText;
        }

        private void ProfileCatalog_SelectionDone(object sender, EventArgs e)
        {
            BoundText = ProfileCatalog.SelectedProfile;
        }
    }
}