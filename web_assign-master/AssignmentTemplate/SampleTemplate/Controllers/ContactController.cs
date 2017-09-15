using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleTemplate.Models;

namespace SampleTemplate.Controllers
{
    public class ContactController : Controller
    {
        DAO dao = new DAO();
        public ActionResult Index()
        {
            List<Feedback> feedbackList = new List<Feedback>()
            {
                new Feedback{ TimeSubmitted = DateTime.Now, Content = "Nothing to see here!", Read = false },
                new Feedback { TimeSubmitted = (DateTime.Now), Content = "This is a mad long comment altogether like it goes on and on and on and on and on and on and on and on and on and on and on and on and on and on and on and on and on!", Read = true }
            };

            return View(feedbackList);
        }
    }
}