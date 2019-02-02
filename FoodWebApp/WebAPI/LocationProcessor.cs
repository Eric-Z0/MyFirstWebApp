using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FoodWebApp.WebAPI
{
    public class LocationProcessor
    {
        // asynchrounous call
        public static async Task<LocationModel> LoadLocation()
        {
            string url = "http://ip-api.com/json";

            // Don't want to leave ports open, do not want to open new ports all the time. this relates to
            // the concern with memory management, network/port management 
            using (HttpResponseMessage response = await LocationAPIHelper.locationAPIClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    // Only transmit the data that match the ones declared in location model
                    LocationModel location = await response.Content.ReadAsAsync<LocationModel>();
                    return location;
                }
                else {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}