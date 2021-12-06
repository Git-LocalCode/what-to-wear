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
using System.Windows.Shapes;
using WhatToWear.Logic.API;

namespace What_to_Wear.Views
{
    /// <summary>
    /// Interaktionslogik für ActivateKey.xaml
    /// </summary>
    public partial class ActivateKey : Window
    {
        public ActivateKey()
        {
            InitializeComponent();
            Key.TextChanged += Key_TextChanged;
        }

        private void Key_TextChanged(object sender, TextChangedEventArgs e)
        {
            Save.Content = "Save";
            Save.IsEnabled = true;
            Key.Background = Brushes.White;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = APIKeyHandler.KeyIsValid(Key.Text);

            if(!isValid)
            {
                Key.Background = Brushes.Red;
                return;
            }

            Key.Background = Brushes.Green;
            APIKeyHandler.SaveAPIKey(Key.Text);
            Save.Content = "Saved";
            Save.IsEnabled = false;
        }
    }
}
