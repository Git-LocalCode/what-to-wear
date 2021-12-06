using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhatToWear.Data.Clothing;
using WhatToWear.Data.Forecast;
using WhatToWear.Logic.Preferences;

namespace WhatToWear.Logic.Clothing
{
    public class ClothingSelector : IClothingSelector
    {
        public List<List<Article>> GetRecommendation(Weather weather)
        {
            List<List<Article>> result = new List<List<Article>>();
            double weathermax = Math.Round(Math.Min(weather.Temperatures.TemperatureMax, 40.0),0);
            double weathermin = Math.Round(Math.Max(weather.Temperatures.TemperatureMin, -20.0),0);
            string clothing = PreferencesHandler.GetPreferences();
            List<Article> constant = PreferencesHandler.ParsePreferences(clothing);
            foreach (ClothingType type in Enum.GetValues(typeof(ClothingType)))
            {
                List<Article> clothes = new List<Article>(constant);
                clothes.RemoveAll(x => x.Type != type);
                clothes.RemoveAll(x => x.Temperatures.TemperatureMax < weathermax || x.Temperatures.TemperatureMin > weathermin);
                if (!clothes.Any())
                    clothes.Add(new Article() { Name = "No appropriate Clothing found", Type = type });

                result.Add(clothes);
            }
            return result;
        }
    }
}
