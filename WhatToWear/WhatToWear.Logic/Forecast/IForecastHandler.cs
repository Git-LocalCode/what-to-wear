using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhatToWear.Data.Forecast;

namespace WhatToWear.Logic.Forecast
{
    public interface IForecastHandler
    {
        Task<WeatherForecast> GetWeatherForecast(double latitude, double longitude);

        Task<WeatherForecast> GetWeatherForecast(string city, string countryAbbreviation);
    }
}
