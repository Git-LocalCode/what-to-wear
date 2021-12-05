using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace What_to_Wear.Views
{
    /// <summary>
    /// Interaktionslogik für HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }
        private void mapControl_MapDoubleTapped(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.MapInputEventArgs e)
        {
            double x = e.Location.Position.Latitude;
            double y = e.Location.Position.Longitude;
        }
    }
}
