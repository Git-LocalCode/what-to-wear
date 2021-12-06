using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using WhatToWear.Data.Clothing;

namespace WhatToWear.Logic.Preferences
{
    public class PreferencesHandler
    {
        public static string GetPreferences()
        {
            try
            {
                string preferences = ConfigurationManager.AppSettings["Pref"];
                if (String.IsNullOrEmpty(preferences))
                    SaveDefault();
            }
            catch
            {
                SaveDefault();
            }

            return ConfigurationManager.AppSettings["Pref"];
        }

        public static void SavePreferences(string pref)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings.Remove("Pref");
            configuration.AppSettings.Settings.Add("Pref", pref);
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection(configuration.AppSettings.SectionInformation.Name);
        }

        public static string ParsePreferences(List<Article> articles)
        {
            return JsonConvert.SerializeObject(articles);
        }

        public static List<Article> ParsePreferences(string articles)
        {
            return JsonConvert.DeserializeObject<List<Article>>(articles);
        }

        public static void SaveDefault()
        {
            List<Article> defaults = GetDefaults();
            string serializedArticles = JsonConvert.SerializeObject(defaults);
            SavePreferences(serializedArticles);
        }

        private static List<Article> GetDefaults()
        {
            List<Article> defaults = new List<Article>();
            defaults.Add(new Article()
            {
                Name = "Double-Layered Hooded Down Jacket",
                Type = ClothingType.Outerwear,
                Temperatures = new Data.Temperatures() { TemperatureMax = 0.0, TemperatureMin = -20.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Waterproof Double-Layered Hooded Down Jacket",
                Type = ClothingType.Outerwear,
                Temperatures = new Data.Temperatures() { TemperatureMax = 0.0, TemperatureMin = -20.0 },
                IsWaterproof = true
            });
            defaults.Add(new Article()
            {
                Name = "Down Jacket",
                Type = ClothingType.Outerwear,
                Temperatures = new Data.Temperatures() { TemperatureMax = 10.0, TemperatureMin = -5.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Waterproof Down Jacket",
                Type = ClothingType.Outerwear,
                Temperatures = new Data.Temperatures() { TemperatureMax = 10.0, TemperatureMin = -5.0 },
                IsWaterproof = true
            });
            defaults.Add(new Article()
            {
                Name = "Puffer Coat",
                Type = ClothingType.Outerwear,
                Temperatures = new Data.Temperatures() { TemperatureMax = 10.0, TemperatureMin = -5.0 },
                IsWaterproof = true
            });
            defaults.Add(new Article()
            {
                Name = "Padded Coat",
                Type = ClothingType.Outerwear,
                Temperatures = new Data.Temperatures() { TemperatureMax = 10.0, TemperatureMin = -5.0 },
                IsWaterproof = true
            });
            defaults.Add(new Article()
            {
                Name = "Overcoat",
                Type = ClothingType.Outerwear,
                Temperatures = new Data.Temperatures() { TemperatureMax = 10.0, TemperatureMin = -5.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Leather Jacket",
                Type = ClothingType.Outerwear,
                Temperatures = new Data.Temperatures() { TemperatureMax = 20.0, TemperatureMin = 10.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Parka",
                Type = ClothingType.Outerwear,
                Temperatures = new Data.Temperatures() { TemperatureMax = 20.0, TemperatureMin = 10.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Leather Jacket",
                Type = ClothingType.Outerwear,
                Temperatures = new Data.Temperatures() { TemperatureMax = 20.0, TemperatureMin = 10.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Pea Coat",
                Type = ClothingType.Outerwear,
                Temperatures = new Data.Temperatures() { TemperatureMax = 20.0, TemperatureMin = 10.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Raincoat",
                Type = ClothingType.Outerwear,
                Temperatures = new Data.Temperatures() { TemperatureMax = 20.0, TemperatureMin = 10.0 },
                IsWaterproof = true
            });
            defaults.Add(new Article()
            {
                Name = "Sweater",
                Type = ClothingType.Tops,
                Temperatures = new Data.Temperatures() { TemperatureMax = 20.0, TemperatureMin = -20.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Jumper",
                Type = ClothingType.Tops,
                Temperatures = new Data.Temperatures() { TemperatureMax = 20.0, TemperatureMin = -20.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Turtleneck",
                Type = ClothingType.Tops,
                Temperatures = new Data.Temperatures() { TemperatureMax = 20.0, TemperatureMin = 0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Shirt",
                Type = ClothingType.Tops,
                Temperatures = new Data.Temperatures() { TemperatureMax = 40.0, TemperatureMin = 15.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Hoodie",
                Type = ClothingType.Tops,
                Temperatures = new Data.Temperatures() { TemperatureMax = 20.0, TemperatureMin = 0.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Dress",
                Type = ClothingType.Tops,
                Temperatures = new Data.Temperatures() { TemperatureMax = 40.0, TemperatureMin = 15.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Pants",
                Type = ClothingType.Bottoms,
                Temperatures = new Data.Temperatures() { TemperatureMax = 5.0, TemperatureMin = -20.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Waterproof Pants",
                Type = ClothingType.Bottoms,
                Temperatures = new Data.Temperatures() { TemperatureMax = 5.0, TemperatureMin = -20.0 },
                IsWaterproof = true
            });
            defaults.Add(new Article()
            {
                Name = "Jeans",
                Type = ClothingType.Bottoms,
                Temperatures = new Data.Temperatures() { TemperatureMax = 20.0, TemperatureMin = 0.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Trousers",
                Type = ClothingType.Bottoms,
                Temperatures = new Data.Temperatures() { TemperatureMax = 20.0, TemperatureMin = 0.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Waterproof Trousers",
                Type = ClothingType.Bottoms,
                Temperatures = new Data.Temperatures() { TemperatureMax = 20.0, TemperatureMin = 0.0 },
                IsWaterproof = true
            });
            defaults.Add(new Article()
            {
                Name = "Shorts or Skirts",
                Type = ClothingType.Bottoms,
                Temperatures = new Data.Temperatures() { TemperatureMax = 40.0, TemperatureMin = 15.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Waterproof Winter Boots",
                Type = ClothingType.Shoes,
                Temperatures = new Data.Temperatures() { TemperatureMax = 0.0, TemperatureMin = -20.0 },
                IsWaterproof = true
            });
            defaults.Add(new Article()
            {
                Name = "Boots",
                Type = ClothingType.Shoes,
                Temperatures = new Data.Temperatures() { TemperatureMax = 10.0, TemperatureMin = 0.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Waterproof Boots",
                Type = ClothingType.Shoes,
                Temperatures = new Data.Temperatures() { TemperatureMax = 10.0, TemperatureMin = 0.0 },
                IsWaterproof = true
            });
            defaults.Add(new Article()
            {
                Name = "Sneakers",
                Type = ClothingType.Shoes,
                Temperatures = new Data.Temperatures() { TemperatureMax = 20.0, TemperatureMin = 10.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Sandals",
                Type = ClothingType.Shoes,
                Temperatures = new Data.Temperatures() { TemperatureMax = 40.0, TemperatureMin = 20.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Earmuffs",
                Type = ClothingType.Headwear,
                Temperatures = new Data.Temperatures() { TemperatureMax = 5.0, TemperatureMin = -20.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Beanie",
                Type = ClothingType.Headwear,
                Temperatures = new Data.Temperatures() { TemperatureMax = 15.0, TemperatureMin = -10.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Sunhats",
                Type = ClothingType.Headwear,
                Temperatures = new Data.Temperatures() { TemperatureMax = 40.0, TemperatureMin = 20.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Cap",
                Type = ClothingType.Headwear,
                Temperatures = new Data.Temperatures() { TemperatureMax = 30.0, TemperatureMin = 15.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Light Gloves",
                Type = ClothingType.Gloves,
                Temperatures = new Data.Temperatures() { TemperatureMax = 10.0, TemperatureMin = 0.0 },
                IsWaterproof = false
            });
            defaults.Add(new Article()
            {
                Name = "Winter Gloves",
                Type = ClothingType.Gloves,
                Temperatures = new Data.Temperatures() { TemperatureMax = 0.0, TemperatureMin = -20.0 },
                IsWaterproof = true
            });

            return defaults;
        }
    }
}
