using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Linq;
using WhatToWear.Data.Forecast;

namespace WhatToWear.Logic.JSON
{
    public class Parser : IParser
    {
        private WeatherForecast _WeatherForecast;

        public WeatherForecast ParseToWeatherForecast(string content)
        {
            dynamic values = JsonConvert.DeserializeObject(content);
            
            _WeatherForecast = new WeatherForecast();

            _WeatherForecast.Location.Address.City = values.city.name;
            _WeatherForecast.Location.Address.Country = values.city.country;

            _WeatherForecast.Location.Coordinates.Latitude = Convert.ToDouble(values.city.coord.lat);
            _WeatherForecast.Location.Coordinates.Longitude = Convert.ToDouble(values.city.coord.lon);

            foreach (dynamic value in values.list)
            {
                AddDayWeathers(value);
            }


            return _WeatherForecast;
        }

        private void AddDayWeathers(dynamic entry)
        {
            if (entry.sys.pod == "d")
            {
                AddWeather(entry);
            }
        }

        private void AddWeather(dynamic entry)
        {
            Weather temp = new Weather();
            temp.Time = Convert.ToDateTime(entry.dt_txt);

            if (!_WeatherForecast.Weathers.Where(value => value.Time.Date == temp.Time.Date).Any())
            {
                temp.Temperatures.TemperatureMax = Convert.ToDouble(entry.main.feels_like);
                temp.Temperatures.TemperatureMin = Convert.ToDouble(entry.main.feels_like);
                temp.ChanceOfPrecipitation = Convert.ToDouble(entry.pop);

                foreach(dynamic desc in entry.weather)
                {
                    temp.Description = desc.description;
                    string iconcode = desc.icon;
                    temp.iconCode = Convert.ToInt32(iconcode.Remove(2));
                }
                    
                
                _WeatherForecast.Weathers.Add(temp);
                return;
            }

            int index = _WeatherForecast.Weathers.FindIndex(value => value.Time.Date == temp.Time.Date);
            _WeatherForecast.Weathers[index].Temperatures.TemperatureMax = Math.Max(_WeatherForecast.Weathers[index].Temperatures.TemperatureMax, Convert.ToDouble(entry.main.feels_like));
            _WeatherForecast.Weathers[index].Temperatures.TemperatureMin = Math.Min(_WeatherForecast.Weathers[index].Temperatures.TemperatureMin, Convert.ToDouble(entry.main.feels_like));
            _WeatherForecast.Weathers[index].ChanceOfPrecipitation = Math.Max(_WeatherForecast.Weathers[index].ChanceOfPrecipitation, Convert.ToDouble(entry.pop));

            foreach (dynamic desc in entry.weather)
            {
                string iconcode = desc.icon;
                int iconCode = Convert.ToInt32(iconcode.Remove(2));
                if (_WeatherForecast.Weathers[index].iconCode < iconCode)
                {
                    _WeatherForecast.Weathers[index].iconCode = iconCode;
                    _WeatherForecast.Weathers[index].Description = desc.description;
                }
            }
        }
    }
}
