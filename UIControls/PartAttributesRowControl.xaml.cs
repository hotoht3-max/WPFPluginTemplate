using System;
using System.Windows;
using System.Windows.Controls;

namespace Apibim.Plugins.BuiltUpColumn.UIControls
{
    public partial class PartAttributesRowControl : UserControl
    {
        public static readonly DependencyProperty RowLabelProperty = DependencyProperty.Register("RowLabel", typeof(string), typeof(PartAttributesRowControl), new PropertyMetadata("Деталь"));
        public string RowLabel { get { return (string)GetValue(RowLabelProperty); } set { SetValue(RowLabelProperty, value); } }

        // --- ЗНАЧЕНИЯ (Двусторонние привязки) ---
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

        public static readonly DependencyProperty PartNameProperty = DependencyProperty.Register("PartName", typeof(string), typeof(PartAttributesRowControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string PartName { get { return (string)GetValue(PartNameProperty); } set { SetValue(PartNameProperty, value); } }

        public static readonly DependencyProperty PartClassProperty = DependencyProperty.Register("PartClass", typeof(string), typeof(PartAttributesRowControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string PartClass { get { return (string)GetValue(PartClassProperty); } set { SetValue(PartClassProperty, value); } }

        // --- ИМЕНА АТРИБУТОВ (Передаются из MainWindow) ---
        public static readonly DependencyProperty ProfileAttrProperty = DependencyProperty.Register("ProfileAttr", typeof(string), typeof(PartAttributesRowControl), new PropertyMetadata(string.Empty));
        public string ProfileAttr { get { return (string)GetValue(ProfileAttrProperty); } set { SetValue(ProfileAttrProperty, value); } }

        public static readonly DependencyProperty MaterialAttrProperty = DependencyProperty.Register("MaterialAttr", typeof(string), typeof(PartAttributesRowControl), new PropertyMetadata(string.Empty));
        public string MaterialAttr { get { return (string)GetValue(MaterialAttrProperty); } set { SetValue(MaterialAttrProperty, value); } }

        public static readonly DependencyProperty PartPrefixAttrProperty = DependencyProperty.Register("PartPrefixAttr", typeof(string), typeof(PartAttributesRowControl), new PropertyMetadata(string.Empty));
        public string PartPrefixAttr { get { return (string)GetValue(PartPrefixAttrProperty); } set { SetValue(PartPrefixAttrProperty, value); } }

        public static readonly DependencyProperty PartStartNoAttrProperty = DependencyProperty.Register("PartStartNoAttr", typeof(string), typeof(PartAttributesRowControl), new PropertyMetadata(string.Empty));
        public string PartStartNoAttr { get { return (string)GetValue(PartStartNoAttrProperty); } set { SetValue(PartStartNoAttrProperty, value); } }

        public static readonly DependencyProperty AssemblyPrefixAttrProperty = DependencyProperty.Register("AssemblyPrefixAttr", typeof(string), typeof(PartAttributesRowControl), new PropertyMetadata(string.Empty));
        public string AssemblyPrefixAttr { get { return (string)GetValue(AssemblyPrefixAttrProperty); } set { SetValue(AssemblyPrefixAttrProperty, value); } }

        public static readonly DependencyProperty AssemblyStartNoAttrProperty = DependencyProperty.Register("AssemblyStartNoAttr", typeof(string), typeof(PartAttributesRowControl), new PropertyMetadata(string.Empty));
        public string AssemblyStartNoAttr { get { return (string)GetValue(AssemblyStartNoAttrProperty); } set { SetValue(AssemblyStartNoAttrProperty, value); } }

        public static readonly DependencyProperty PartNameAttrProperty = DependencyProperty.Register("PartNameAttr", typeof(string), typeof(PartAttributesRowControl), new PropertyMetadata(string.Empty));
        public string PartNameAttr { get { return (string)GetValue(PartNameAttrProperty); } set { SetValue(PartNameAttrProperty, value); } }

        public static readonly DependencyProperty PartClassAttrProperty = DependencyProperty.Register("PartClassAttr", typeof(string), typeof(PartAttributesRowControl), new PropertyMetadata(string.Empty));
        public string PartClassAttr { get { return (string)GetValue(PartClassAttrProperty); } set { SetValue(PartClassAttrProperty, value); } }

        public static readonly DependencyProperty UdaAttrProperty = DependencyProperty.Register("UdaAttr", typeof(string), typeof(PartAttributesRowControl), new PropertyMetadata(string.Empty));
        public string UdaAttr { get { return (string)GetValue(UdaAttrProperty); } set { SetValue(UdaAttrProperty, value); } }

        public PartAttributesRowControl()
        {
            InitializeComponent();
            this.Loaded += PartAttributesRowControl_Loaded; // Подписка на загрузку
        }

        // --- ВНЕДРЕНИЕ ИМЕН АТРИБУТОВ ЧЕРЕЗ C# ---
        private void PartAttributesRowControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (ChkProfile != null) ChkProfile.AttributeName = ProfileAttr;
            if (ChkMaterial != null) ChkMaterial.AttributeName = MaterialAttr;
            if (ChkPartPrefix != null) ChkPartPrefix.AttributeName = PartPrefixAttr;
            if (ChkPartStartNo != null) ChkPartStartNo.AttributeName = PartStartNoAttr;
            if (ChkAssemblyPrefix != null) ChkAssemblyPrefix.AttributeName = AssemblyPrefixAttr;
            if (ChkAssemblyStartNo != null) ChkAssemblyStartNo.AttributeName = AssemblyStartNoAttr;
            if (ChkPartName != null) ChkPartName.AttributeName = PartNameAttr;
            if (ChkPartClass != null) ChkPartClass.AttributeName = PartClassAttr;
            if (ChkUda != null) ChkUda.AttributeName = UdaAttr;
        }

        private void ProfileCatalog_SelectClicked(object sender, EventArgs e) => ProfileCatalog.SelectedProfile = Profile;
        private void ProfileCatalog_SelectionDone(object sender, EventArgs e) => Profile = ProfileCatalog.SelectedProfile;

        private void MaterialCatalog_SelectClicked(object sender, EventArgs e) => MaterialCatalog.SelectedMaterial = Material;
        private void MaterialCatalog_SelectionDone(object sender, EventArgs e) => Material = MaterialCatalog.SelectedMaterial;

        // --- ЛОГИКА МАСТЕР-ГАЛОЧКИ ---
        private void MasterChk_Click(object sender, RoutedEventArgs e)
        {
            bool isChecked = MasterChk.IsChecked == true;
            if (ChkProfile != null) ChkProfile.IsChecked = isChecked;
            if (ChkMaterial != null) ChkMaterial.IsChecked = isChecked;
            if (ChkPartPrefix != null) ChkPartPrefix.IsChecked = isChecked;
            if (ChkPartStartNo != null) ChkPartStartNo.IsChecked = isChecked;
            if (ChkAssemblyPrefix != null) ChkAssemblyPrefix.IsChecked = isChecked;
            if (ChkAssemblyStartNo != null) ChkAssemblyStartNo.IsChecked = isChecked;
            if (ChkPartName != null) ChkPartName.IsChecked = isChecked;
            if (ChkPartClass != null) ChkPartClass.IsChecked = isChecked;
            if (ChkUda != null) ChkUda.IsChecked = isChecked;
        }
    }
}