using System.Windows;
using System.Windows.Controls;

namespace Apibim.Plugins.BuiltUpColumn.UIControls
{
    public partial class PositioningRowControl : UserControl
    {
        public static readonly DependencyProperty RowLabelProperty = DependencyProperty.Register("RowLabel", typeof(string), typeof(PositioningRowControl), new PropertyMetadata("Позиция:"));
        public string RowLabel { get { return (string)GetValue(RowLabelProperty); } set { SetValue(RowLabelProperty, value); } }

        // --- ЗНАЧЕНИЯ ---
        public static readonly DependencyProperty PosPlaneProperty = DependencyProperty.Register("PosPlane", typeof(int), typeof(PositioningRowControl), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public int PosPlane { get { return (int)GetValue(PosPlaneProperty); } set { SetValue(PosPlaneProperty, value); } }
        public static readonly DependencyProperty PosPlaneOffProperty = DependencyProperty.Register("PosPlaneOff", typeof(double), typeof(PositioningRowControl), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public double PosPlaneOff { get { return (double)GetValue(PosPlaneOffProperty); } set { SetValue(PosPlaneOffProperty, value); } }

        public static readonly DependencyProperty PosRotProperty = DependencyProperty.Register("PosRot", typeof(int), typeof(PositioningRowControl), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public int PosRot { get { return (int)GetValue(PosRotProperty); } set { SetValue(PosRotProperty, value); } }
        public static readonly DependencyProperty PosRotOffProperty = DependencyProperty.Register("PosRotOff", typeof(double), typeof(PositioningRowControl), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public double PosRotOff { get { return (double)GetValue(PosRotOffProperty); } set { SetValue(PosRotOffProperty, value); } }

        public static readonly DependencyProperty PosDepthProperty = DependencyProperty.Register("PosDepth", typeof(int), typeof(PositioningRowControl), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public int PosDepth { get { return (int)GetValue(PosDepthProperty); } set { SetValue(PosDepthProperty, value); } }
        public static readonly DependencyProperty PosDepthOffProperty = DependencyProperty.Register("PosDepthOff", typeof(double), typeof(PositioningRowControl), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public double PosDepthOff { get { return (double)GetValue(PosDepthOffProperty); } set { SetValue(PosDepthOffProperty, value); } }

        // --- АТРИБУТЫ ---
        public static readonly DependencyProperty PosPlaneAttrProperty = DependencyProperty.Register("PosPlaneAttr", typeof(string), typeof(PositioningRowControl));
        public string PosPlaneAttr { get { return (string)GetValue(PosPlaneAttrProperty); } set { SetValue(PosPlaneAttrProperty, value); } }
        public static readonly DependencyProperty PosPlaneOffAttrProperty = DependencyProperty.Register("PosPlaneOffAttr", typeof(string), typeof(PositioningRowControl));
        public string PosPlaneOffAttr { get { return (string)GetValue(PosPlaneOffAttrProperty); } set { SetValue(PosPlaneOffAttrProperty, value); } }

        public static readonly DependencyProperty PosRotAttrProperty = DependencyProperty.Register("PosRotAttr", typeof(string), typeof(PositioningRowControl));
        public string PosRotAttr { get { return (string)GetValue(PosRotAttrProperty); } set { SetValue(PosRotAttrProperty, value); } }
        public static readonly DependencyProperty PosRotOffAttrProperty = DependencyProperty.Register("PosRotOffAttr", typeof(string), typeof(PositioningRowControl));
        public string PosRotOffAttr { get { return (string)GetValue(PosRotOffAttrProperty); } set { SetValue(PosRotOffAttrProperty, value); } }

        public static readonly DependencyProperty PosDepthAttrProperty = DependencyProperty.Register("PosDepthAttr", typeof(string), typeof(PositioningRowControl));
        public string PosDepthAttr { get { return (string)GetValue(PosDepthAttrProperty); } set { SetValue(PosDepthAttrProperty, value); } }
        public static readonly DependencyProperty PosDepthOffAttrProperty = DependencyProperty.Register("PosDepthOffAttr", typeof(string), typeof(PositioningRowControl));
        public string PosDepthOffAttr { get { return (string)GetValue(PosDepthOffAttrProperty); } set { SetValue(PosDepthOffAttrProperty, value); } }

        public PositioningRowControl()
        {
            InitializeComponent();
        }

        private void PositioningRowControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (ChkPlane != null) ChkPlane.AttributeName = PosPlaneAttr;
            if (ChkPlaneOff != null) ChkPlaneOff.AttributeName = PosPlaneOffAttr;
            if (ChkRot != null) ChkRot.AttributeName = PosRotAttr;
            if (ChkRotOff != null) ChkRotOff.AttributeName = PosRotOffAttr;
            if (ChkDepth != null) ChkDepth.AttributeName = PosDepthAttr;
            if (ChkDepthOff != null) ChkDepthOff.AttributeName = PosDepthOffAttr;
        }

        // Метод для мастер-галочки из родительского контрола
        public void ToggleAll(bool isChecked)
        {
            if (ChkPlane != null) ChkPlane.IsChecked = isChecked;
            if (ChkPlaneOff != null) ChkPlaneOff.IsChecked = isChecked;
            if (ChkRot != null) ChkRot.IsChecked = isChecked;
            if (ChkRotOff != null) ChkRotOff.IsChecked = isChecked;
            if (ChkDepth != null) ChkDepth.IsChecked = isChecked;
            if (ChkDepthOff != null) ChkDepthOff.IsChecked = isChecked;
        }
    }
}