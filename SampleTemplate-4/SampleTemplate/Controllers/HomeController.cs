using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace SampleTemplate.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //string pass1 = "blue";
            //string pass2 = "green";

            //string hashedValue = Crypto.HashPassword(pass1);
            //if (Crypto.VerifyHashedPassword(hashedValue, pass2))
            //{
            //    ViewBag.Value = "Success; both passwords match";
            //}
            //else ViewBag.Value = "Error! passwords do not match";
            return View();
        }
    }
}