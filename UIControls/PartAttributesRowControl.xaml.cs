using System;
using System.Windows;
using System.Windows.Controls;

namespace Apibim.Plugins.BuiltUpColumn.UIControls
{
    public partial class PartAttributesRowControl : UserControl
    {
        public static readonly DependencyProperty RowLabelProperty = DependencyProperty.Register("RowLabel", typeof(string), typeof(PartAttributesRowControl), new PropertyMetadata("Деталь"));
        public string RowLabel { get { return (string)GetValue(RowLabelProperty); } set { SetValue(RowLabelProperty, value); } }

        public static readonly DependencyProperty ProfileProperty = DependencyProperty.Register("Profile", typeof(string), typeof(PartAttributesRowControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string Profile { get { return (string)GetValue(ProfileProperty); } set { SetValue(ProfileProperty, value); } }

        public static readonly DependencyProperty MaterialProperty = DependencyProperty.Register("Material", typeof(string), typeof(PartAttributesRowControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string Material { get { return (string)GetValue(MaterialProperty); } set { SetValue(MaterialProperty, value); } }

        public static readonly DependencyProperty PartPrefixProperty = DependencyProperty.Register("PartPrefix", typeof(string), typeof(PartAttributesRowControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string PartPrefix { get { return (string)GetValue(PartPrefixProperty); } set { SetValue(PartPrefixProperty, value); } }

        public static readonly DependencyProperty PartStartNoProperty = DependencyProperty.Register("PartStartNo", typeof(string), typeof(PartAttributesRowControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string PartStartNo { get { return (string)GetValue(PartStartNoProperty); } set { SetValue(PartStartNoProperty, value); } }

        public static readonly DependencyProperty AssemblyPrefixProperty = DependencyProperty.Register("AssemblyPrefix", typeof(string), typeof(PartAttributesRowControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string AssemblyPrefix { get { return (string)GetValue(AssemblyPrefixProperty); } set { SetValue(AssemblyPrefixProperty, value); } }

        public static readonly DependencyProperty AssemblyStartNoProperty = DependencyProperty.Register("AssemblyStartNo", typeof(string), typeof(PartAttributesRowControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string AssemblyStartNo { get { return (string)GetValue(AssemblyStartNoProperty); } set { SetValue(AssemblyStartNoProperty, value); } }

        public static readonly DependencyProperty PartClassProperty = DependencyProperty.Register("PartClass", typeof(string), typeof(PartAttributesRowControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string PartClass { get { return (string)GetValue(PartClassProperty); } set { SetValue(PartClassProperty, value); } }

        public PartAttributesRowControl()
        {
            InitializeComponent();
        }

        private void ProfileCatalog_SelectClicked(object sender, EventArgs e)
        {
            ProfileCatalog.SelectedProfile = Profile;
        }

        private void ProfileCatalog_SelectionDone(object sender, EventArgs e)
        {
            Profile = ProfileCatalog.SelectedProfile;
        }

        private void MaterialCatalog_SelectClicked(object sender, EventArgs e)
        {
            MaterialCatalog.SelectedMaterial = Material;
        }

        private void MaterialCatalog_SelectionDone(object sender, EventArgs e)
        {
            Material = MaterialCatalog.SelectedMaterial;
        }
    }
}