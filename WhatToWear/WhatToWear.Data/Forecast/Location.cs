using System;
using System.Collections.Generic;
using System.Text;

namespace WhatToWear.Data.Forecast
{
    public class Location
    {
        public Address Address { get; set; }

        public Coordinates Coordinates { get; set; }

        public Location()
        {
            Address = new Address();
            Coordinates = new Coordinates();
        }
    }
}
