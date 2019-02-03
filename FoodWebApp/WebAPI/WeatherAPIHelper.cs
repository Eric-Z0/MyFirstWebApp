using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace FoodWebApp.WebAPI
{
    public static class WeatherAPIHelper
    {
        // Declare the http client as static because we want to open it once per application 
        public static HttpClient weatherAPIClient { get; set; } 

        public static void InitializeClient() {
            weatherAPIClient = new HttpClient();
            // Set the base url address
            weatherAPIClient.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
            weatherAPIClient.DefaultRequestHeaders.Accept.Clear();
            // Add a header which requests JSON type data
            weatherAPIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}