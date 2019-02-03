using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FoodWebApp.WebAPI
{
    public class WeatherProcessor
    {
        // asynchrounous call
        public static async Task<WeatherModel> LoadWeather(string City, string CountryCode)
        {
            string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0},{1}&appid=f7faebb1937cb4646a23d12715b37939", City, CountryCode);

            // Don't want to leave ports open, do not want to open new ports all the time. this relates to
            // the concern with memory management, network/port management 
            using (HttpResponseMessage response = await WeatherAPIHelper.weatherAPIClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    // Only transmit the data that match the ones declared in weather model
                    WeatherModel weather = await response.Content.ReadAsAsync<WeatherModel>();
                    //Debug.WriteLine("WeatherObj-data: {0}", weather.WeatherData, null);
                    return weather;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}