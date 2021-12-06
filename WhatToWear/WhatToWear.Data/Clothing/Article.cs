using Newtonsoft.Json;


namespace WhatToWear.Data.Clothing
{
    public enum ClothingType
    {
        Headwear    = 1,
        Outerwear      = 2,
        Tops       = 3,
        Gloves      = 4,
        Bottoms       = 5,
        Shoes       = 6
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Article
    {
        [JsonProperty]
        public ClothingType Type { get; set; }

        [JsonProperty]
        public string Name { get; set; }
         
        [JsonProperty]
        public Temperatures Temperatures { get; set; }

        [JsonProperty]
        public bool IsWaterproof { get; set; }

        public Article()
        {
            Temperatures = new Temperatures();
        }

        public override string ToString()
        {
            return $"{Type}, {Name}: {Temperatures.TemperatureMin}°C to {Temperatures.TemperatureMax}°C, {Waterproof(IsWaterproof)}";
        }

        private string Waterproof(bool waterproof)
        {
            if (waterproof)
                return "Waterproof";
            return "not Waterproof";
        }
    }
}
