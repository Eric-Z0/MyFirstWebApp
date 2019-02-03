using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace FoodWebApp.WebAPI
{
    public class WeatherModel
    {
        // Standard C# casing (Pascal casing)
        // This helped me learn how to associate model attributes with 
        // thier corresponding ones in nested Json data structure

        [JsonProperty(PropertyName = "weather")]
        public List<Weather> WeatherStates { get; set; }

        [JsonProperty(PropertyName = "main")]
        public Main WeatherData { get; set; }
    }

    public class Weather
    {
        //[JsonProperty(PropertyName = "main")]
        public string Main { get; set; }

        //[JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }

    public class Main
    {
        //[JsonProperty(PropertyName = "temp")]
        public string Temp { get; set; }

        //[JsonProperty(PropertyName = "humidity")]
        public string Humidity { get; set; }

        [JsonProperty(PropertyName = "temp_min")]
        public string TempMin { get; set; }

        [JsonProperty(PropertyName = "temp_max")]
        public string TempMax { get; set; }

    }
}