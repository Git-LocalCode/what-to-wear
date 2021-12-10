using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using WhatToWear.Data.Clothing;
using WhatToWear.Data.Forecast;
using WhatToWear.Logic.Clothing;
using WhatToWear.Logic.Forecast;
using Windows.UI.Xaml.Controls.Maps;

namespace What_to_Wear.Views
{
    /// <summary>
    /// Interaktionslogik für HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private MapIcon _LocationIcon;

        public HomeView()
        {
            InitializeComponent();
        }
        private void mapControl_MapDoubleTapped(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.MapInputEventArgs e)
        {
            Map.MapElements.Clear();
            double x = e.Location.Position.Latitude;
            double y = e.Location.Position.Longitude;
            ShowWeatherForecast(x, y);

            Windows.Devices.Geolocation.Geopoint myPoint = new Windows.Devices.Geolocation.Geopoint(new Windows.Devices.Geolocation.BasicGeoposition() { Latitude = x, Longitude = y });
            //create POI
            _LocationIcon = new MapIcon { Location = myPoint, Title = "", ZIndex = 0 };
            // add to map and center it
            Map.MapElements.Add(_LocationIcon);
        }

        private async void ShowWeatherForecast(double lat, double lon)
        {
            IForecastHandler forecastHandler = new ForecastHandler();
            WeatherForecast weatherforecast = await forecastHandler.GetWeatherForecast(lat, lon);
            IClothingSelector clothingSelector = new ClothingSelector();
            TxtCityName.Text = $"{weatherforecast.Location.Address.City}, {weatherforecast.Location.Address.Country}";
            _LocationIcon.Title = $"{weatherforecast.Location.Address.City}, {weatherforecast.Location.Address.Country}";
            for (int i = 0; i < weatherforecast.Weathers.Count; i++)
            {
                List<List<Article>> recommendation = clothingSelector.GetRecommendation(weatherforecast.Weathers[i]);
                Grid currentGrid;
                TextBlock currentText;
                switch(i)
                {
                    case 0: currentGrid = GridOne; currentText = DayOne; break;
                    case 1: currentGrid = GridTwo; currentText = DayTwo; break;
                    case 2: currentGrid = GridThree; currentText = DayThree; break;
                    case 3: currentGrid = GridFour; currentText = DayFour; break;
                    case 4: currentGrid = GridFive; currentText = DayFive; break;
                    default: currentGrid = new Grid(); currentText = new TextBlock(); break;
                }

                for (int j = 0; j < Enum.GetValues(typeof(ClothingType)).Length; j++)
                {
                    ComboBox clothing = new ComboBox();
                    currentGrid.Children.Add(clothing);
                    Grid.SetRow(clothing, j);
                    recommendation[j] = recommendation[j].GroupBy(x => x.Name).Select(x => x.First()).ToList();
                    foreach(var recom in recommendation[j])
                    {
                        clothing.Items.Add(recom.Name);
                    }
                    clothing.SelectedIndex = 0;
                }
                currentText.Text = weatherforecast.Weathers[i].Time.ToShortDateString();
            }
            WeatherOne.Text = $"{weatherforecast.Weathers[0].Description}\n{Math.Round(weatherforecast.Weathers[0].Temperatures.TemperatureMin,0)}°C to {Math.Round(weatherforecast.Weathers[0].Temperatures.TemperatureMax,0)}°C\n{(weatherforecast.Weathers[0].ChanceOfPrecipitation * 100).ToString("0")}% Chance of Precipitation";
            WeatherTwo.Text = $"{weatherforecast.Weathers[1].Description}\n{Math.Round(weatherforecast.Weathers[1].Temperatures.TemperatureMin,0)}°C to {Math.Round(weatherforecast.Weathers[1].Temperatures.TemperatureMax,0)}°C\n{(weatherforecast.Weathers[1].ChanceOfPrecipitation * 100).ToString("0")}% Chance of Precipitation";
            WeatherThree.Text = $"{weatherforecast.Weathers[2].Description}\n{Math.Round(weatherforecast.Weathers[2].Temperatures.TemperatureMin,0)}°C to {Math.Round(weatherforecast.Weathers[2].Temperatures.TemperatureMax,0)}°C\n{(weatherforecast.Weathers[2].ChanceOfPrecipitation * 100).ToString("0")}% Chance of Precipitation";
            WeatherFour.Text = $"{weatherforecast.Weathers[3].Description}\n{Math.Round(weatherforecast.Weathers[3].Temperatures.TemperatureMin,0)}°C to {Math.Round(weatherforecast.Weathers[3].Temperatures.TemperatureMax,0)}°C\n{(weatherforecast.Weathers[3].ChanceOfPrecipitation * 100).ToString("0")}% Chance of Precipitation";
            WeatherFive.Text = $"{weatherforecast.Weathers[4].Description}\n{Math.Round(weatherforecast.Weathers[4].Temperatures.TemperatureMin,0)}°C to {Math.Round(weatherforecast.Weathers[4].Temperatures.TemperatureMax,0)}°C\n{(weatherforecast.Weathers[4].ChanceOfPrecipitation * 100).ToString("0")}% Chance of Precipitation";

            WeatherIconOne.Source = new BitmapImage(new Uri(IconHandler.GetURL(weatherforecast.Weathers[0].iconCode), UriKind.RelativeOrAbsolute));
            WeatherIconTwo.Source = new BitmapImage(new Uri(IconHandler.GetURL(weatherforecast.Weathers[1].iconCode), UriKind.RelativeOrAbsolute));
            WeatherIconThree.Source = new BitmapImage(new Uri(IconHandler.GetURL(weatherforecast.Weathers[2].iconCode), UriKind.RelativeOrAbsolute));
            WeatherIconFour.Source = new BitmapImage(new Uri(IconHandler.GetURL(weatherforecast.Weathers[3].iconCode), UriKind.RelativeOrAbsolute));
            WeatherIconFive.Source = new BitmapImage(new Uri(IconHandler.GetURL(weatherforecast.Weathers[4].iconCode), UriKind.RelativeOrAbsolute));
        }
    }
}
