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

namespace whattowear.Views
{
    /// <summary>
    /// Interaktionslogik für Preferences.xaml
    /// </summary>
    public partial class Preferences : Page
    {
        public Preferences()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Views/Home.xaml", UriKind.Relative));
        }
    }
}
