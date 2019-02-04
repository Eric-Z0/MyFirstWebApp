using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FoodWebApp.WebAPI
{
    public class NewsProcessor
    {
        // asynchrounous call
        public static async Task<NewsModel> LoadNews()
        {
            string url = "https://newsapi.org/v2/everything?" + "q=Canada&" + "from=2019-02-03&" + "sortBy=popularity&" + "apiKey=62b8033b09104c199616cb505b440b4a";

            // Don't want to leave ports open, do not want to open new ports all the time. this relates to
            // the concern with memory management, network/port management 
            using (HttpResponseMessage response = await NewsAPIHelper.newsAPIClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    //object news = await response.Content.ReadAsAsync<object>();
                    // Only transmit the data that match the ones declared in location model
                    NewsModel news = await response.Content.ReadAsAsync<NewsModel>();
                    return news;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}