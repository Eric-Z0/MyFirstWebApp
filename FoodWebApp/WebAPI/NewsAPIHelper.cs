using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace FoodWebApp.WebAPI
{
    public class NewsAPIHelper
    {
        // Declare the http client as static because we want to open it once per application 
        public static HttpClient newsAPIClient { get; set; }

        public static void InitializeClient()
        {
            newsAPIClient = new HttpClient();
            // Set the base url address
            newsAPIClient.BaseAddress = new Uri("https://newsapi.org/v2");
            newsAPIClient.DefaultRequestHeaders.Accept.Clear();
            // Add a header which requests JSON type data
            newsAPIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}