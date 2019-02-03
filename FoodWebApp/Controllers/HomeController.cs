using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;
using FoodWebApp.DB_Service;
using FoodWebApp.Models;
using FoodWebApp.WebAPI;

namespace FoodWebApp.Controllers
{
    public class HomeController : Controller
    {
        private async Task LoadLocation()
        {
            var location = await LocationProcessor.LoadLocation();

            Debug.WriteLine("Current Country: {0}", location.Country, null);
            Debug.WriteLine("Current CountryCode: {0}", location.CountryCode, null);
            Debug.WriteLine("Current City: {0}", location.City, null);

            // Call LoadWeather API here
            await LoadWeather(location.City, location.CountryCode);
        }

        private async Task LoadWeather(string City, string CountryCode)
        {
            var weather = await WeatherProcessor.LoadWeather(City, CountryCode);

            //Debug.WriteLine("WeatherObj-attr: {0}", weather.Humidity, null);
            Debug.WriteLine("Weather Con: {0}", weather.WeatherStates[0].Main, null);
            Debug.WriteLine("Temp: {0}", weather.WeatherData.Temp, null);
            Debug.WriteLine("Humidity: {0}", weather.WeatherData.Humidity, null);
            Debug.WriteLine("Temp Min: {0}", weather.WeatherData.TempMin, null);
            Debug.WriteLine("Temp Max: {0}", weather.WeatherData.TempMax, null);
        }

        public async Task<ActionResult> Index()
        {
            LocationAPIHelper.InitializeClient();
            WeatherAPIHelper.InitializeClient();
            await LoadLocation();

            return View();
        }

        public ActionResult Message()
        {
            ViewBag.Message = "My Message Page.";

            return View();
        }

        public ActionResult Profile()
        {
            ViewBag.Message = "My Profile Page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "My Login Page.";

            return View();
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "User SignUp Page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserModel user)
        {
            // The reason the request is validated the second time is because the front-end validation can be spoofed under special situation
            if (ModelState.IsValid)
            {
                //------------------- For test purpose ---------------------
                Debug.WriteLine("UserName: {0}", user.UserName, null);
                Debug.WriteLine("UserPWD: {0}", user.Password, null);
                Debug.WriteLine("Email: {0}", user.EmailAddress, null);

                UserService userService = new UserService();
                var userList = userService.Get();

                foreach (object data in userList) {
                    Debug.WriteLine(data);
                }
                //--------------------- End of test ------------------------

                userService.Create(user);

                return RedirectToAction("Index");
            }
            else {
                // Users will stay in the SignUp page 
                return View();
            }
        }
    }
}