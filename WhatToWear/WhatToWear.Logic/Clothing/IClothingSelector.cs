using System;
using System.Collections.Generic;
using System.Text;
using WhatToWear.Data.Clothing;
using WhatToWear.Data.Forecast;

namespace WhatToWear.Logic.Clothing
{
    public interface IClothingSelector
    {
        List<List<Article>> GetRecommendation(Weather weather);
    }
}
