using System;
using System.Collections.Generic;
using System.Text;
using WhatToWear.Data.Forecast;

namespace WhatToWear.Logic.JSON
{
    public interface IParser
    {
        WeatherForecast ParseToWeatherForecast(string content);
    }
}
