using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebApp.WebAPI
{
    public class LocationModel
    {
        // Standard C# casing (Pascal casing)
        public string Country { get; set; }
        public string City { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }

    }
}