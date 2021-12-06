using System;
using System.Collections.Generic;
using System.Text;

namespace WhatToWear.Data.Forecast
{
    public class Weather
    {
        public DateTime Time { get; set; }

        public Temperatures Temperatures { get; set; }

        public double ChanceOfPrecipitation { get; set; }

        public string Description { get; set; }

        public int iconCode { get; set; }

        public Weather()
        {
            Temperatures = new Temperatures();
        }
    }
}
