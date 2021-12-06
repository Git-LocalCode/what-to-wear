using System;
using System.Collections.Generic;
using WhatToWear.Data.Clothing;
using WhatToWear.Data.Forecast;
using WhatToWear.Logic.API;
using WhatToWear.Logic.Clothing;
using WhatToWear.Logic.Forecast;
using WhatToWear.Logic.Preferences;

namespace WhatToWear.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //PreferencesHandler.SaveDefault();
            //var x = PreferencesHandler.GetPreferences();
            //Console.WriteLine(x);
            IForecastHandler handler = new ForecastHandler();
            WeatherForecast x = handler.GetWeatherForecast(51.5, 12.3730747).Result;



            //IForecastHandler handler = new ForecastHandler();
            //Console.WriteLine("-----------------");
            

            //WeatherForecast x = handler.GetWeatherForecast("Leipzig", "DE").Result;
            Console.WriteLine(x.Location.Address.Country);
            Console.WriteLine(x.Location.Address.City);
            Console.WriteLine(x.Location.Coordinates.Latitude);
            Console.WriteLine(x.Location.Coordinates.Longitude);
            Console.WriteLine("----");
            foreach (var weather in x.Weathers)
            {
                Console.WriteLine(weather.Time);
                Console.WriteLine(weather.Temperatures.TemperatureMax);
                Console.WriteLine(weather.Temperatures.TemperatureMin);
                Console.WriteLine(weather.ChanceOfPrecipitation);
                Console.WriteLine(weather.Description);
                Console.WriteLine(weather.iconCode);
            }

            IClothingSelector selector = new ClothingSelector();
            List<List<Article>> y = selector.GetRecommendation(x.Weathers[0]);
            foreach (var rec in y)
            {
                foreach (var rec2 in rec)
                {
                    Console.WriteLine(rec2);
                }
            }
        }
    }
}
