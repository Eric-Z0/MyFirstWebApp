using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebApp.WebAPI
{
    public class NewsModel
    {
        [JsonProperty(PropertyName = "articles")]
        public List<Article> Articles { get; set; }

    }

    public class Article
    {
        //[JsonProperty(PropertyName = "author")]
        public string Author { get; set; }

        //[JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        //[JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        //[JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        //[JsonProperty(PropertyName = "urlToImage")]
        public string UrlToImage { get; set; }

        //[JsonProperty(PropertyName = "publishedAt")]
        public string PublishedAt { get; set; }
    }
}