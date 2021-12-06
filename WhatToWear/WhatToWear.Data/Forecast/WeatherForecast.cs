using System;
using System.Collections.Generic;
using System.Text;

namespace WhatToWear.Data.Forecast
{
    public class WeatherForecast
    {
        public Location Location { get; set; }

        public List<Weather> Weathers { get; set; }

        public WeatherForecast()
        {
            Location = new Location();
            Weathers = new List<Weather>();
        }
    }
}
