using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Message()
        {
            ViewBag.Message = "My Message Page.";

            return View();
        }

        public ActionResult MAP()
        {
            ViewBag.Message = "My MAP Page.";

            return View();
        }

        public ActionResult Weather()
        {
            ViewBag.Message = "My Weather Page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "My Login Page.";

            return View();
        }

        public ActionResult Signup()
        {
            ViewBag.Message = "My Signup Page.";

            return View();
        }
    }
}