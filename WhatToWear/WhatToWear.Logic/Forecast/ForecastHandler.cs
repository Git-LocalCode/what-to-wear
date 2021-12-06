using System;
using System.Net.Http;
using System.Threading.Tasks;
using WhatToWear.Data.Forecast;
using WhatToWear.Logic.API;
using WhatToWear.Logic.JSON;

namespace WhatToWear.Logic.Forecast
{
    public class ForecastHandler : IForecastHandler
    {
        async Task<WeatherForecast> IForecastHandler.GetWeatherForecast(double latitude, double longitude)
        {
            string parameter = $"lat={latitude}&lon={longitude}";
            HttpResponseMessage response = await GetResponse(parameter);

            IParser parser = new Parser();

            return parser.ParseToWeatherForecast(response.Content.ReadAsStringAsync().Result);
        }

        async Task<WeatherForecast> IForecastHandler.GetWeatherForecast(string city, string countryAbbreviation)
        {
            string parameter = $"q={city},{countryAbbreviation}";
            HttpResponseMessage response = await GetResponse(parameter);

            IParser parser = new Parser();

            return parser.ParseToWeatherForecast(response.Content.ReadAsStringAsync().Result);
        }

        private async Task<HttpResponseMessage> GetResponse(string parameter)
        {
            string url = $"http://api.openweathermap.org/data/2.5/forecast?{parameter}&units=metric&appid={APIKeyHandler.GetAPIKey()}";

            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();
            return await client.GetAsync(uri);
        }
    }
}
