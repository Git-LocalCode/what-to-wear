using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;

namespace WhatToWear.Logic.API
{
    public class APIKeyHandler
    {

        public static string GetAPIKey()
        {
            try
            {
                string key = ConfigurationManager.AppSettings["API"];
                if (String.IsNullOrEmpty(key))
                {
                    SaveAPIKey("a01308f55cbdb4b28232395f3b0828a5");
                    key = "a01308f55cbdb4b28232395f3b0828a5";
                }

                return key;
            }
            catch
            {
                SaveAPIKey("a01308f55cbdb4b28232395f3b0828a5");
                return "a01308f55cbdb4b28232395f3b0828a5";
            }
        }

        public static void SaveAPIKey(string key)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings.Remove("API");
            configuration.AppSettings.Settings.Add("API", key);
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection(configuration.AppSettings.SectionInformation.Name);
        }

        public static bool KeyIsValid(string key)
        {
            string url = $"http://api.openweathermap.org/data/2.5/forecast?lat=51.5&lon=12.3730747&units=metric&appid={key}";
            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(uri).Result;
            string content = response.Content.ReadAsStringAsync().Result;
            dynamic values = JsonConvert.DeserializeObject(content);

            return Convert.ToInt32(values.cod) != 401;
        }
    }
}
