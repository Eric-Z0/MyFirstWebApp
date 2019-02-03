using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace FoodWebApp.WebAPI
{
    public class LocationAPIHelper
    {
        // Declare the http client as static because we want to open it once per application 
        public static HttpClient locationAPIClient { get; set; }

        public static void InitializeClient()
        {
            locationAPIClient = new HttpClient();
            // Set the base url address
            locationAPIClient.BaseAddress = new Uri("http://ip-api.com/json");
            locationAPIClient.DefaultRequestHeaders.Accept.Clear();
            // Add a header which requests JSON type data
            locationAPIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}