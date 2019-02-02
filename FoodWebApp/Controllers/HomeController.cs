﻿using System;
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
            Debug.WriteLine("Current City: {0}", location.City, null);
        }

        public async Task<ActionResult> Index()
        {
            LocationAPIHelper.InitializeClient();
            await LoadLocation();
            //WeatherAPIHelper.InitializeClient();
            return View();
        }

        public ActionResult Message()
        {
            ViewBag.Message = "My Message Page.";

            return View();
        }

        public ActionResult MyProfile()
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
                // For test purpose
                Debug.WriteLine("UserName: {0}", user.UserName, null);
                Debug.WriteLine("UserPWD: {0}", user.Password, null);
                Debug.WriteLine("Email: {0}", user.EmailAddress, null);

                UserService userService = new UserService();
                var userList = userService.Get();
                foreach (object data in userList) {
                    Debug.WriteLine(data);
                }

                userService.Create(user);

                return RedirectToAction("Index");
            }
            else {
                return View();
            }
        }
    }
}