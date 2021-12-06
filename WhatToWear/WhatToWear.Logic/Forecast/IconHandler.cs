using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;

namespace WhatToWear.Logic.Forecast
{
    public class IconHandler
    {
        public static Image GetImage(int iconCode)
        {
            Image result;
            string code = $"{iconCode.ToString("00")}d";
            string url = $"http://openweathermap.org/img/wn/{code}@2x.png";
            Uri uri = new Uri(url);

            using (WebClient client = new WebClient())
            {
                string path = Path.Combine(Path.GetTempPath(), "weather.png");
                client.DownloadFile(uri, path);
                result = Image.FromFile(path);
            }

            return result;
        }

        public static string GetURL(int iconCode)
        {
            string code = $"{iconCode.ToString("00")}d";
            return $"http://openweathermap.org/img/wn/{code}@2x.png";
        }
    }
}
