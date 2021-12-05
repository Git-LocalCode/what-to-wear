using System;
using System.Collections.Generic;
using System.Text;

namespace What_to_Wear.Models
{
    public class ClothModel
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string TemperatureFrom { get; set; }
        public string TemperatureTill { get; set; }
        public bool IsWaterproof { get; set; }
    }
}
