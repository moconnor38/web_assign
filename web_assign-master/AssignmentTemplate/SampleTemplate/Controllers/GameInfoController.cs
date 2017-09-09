using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleTemplate.Models;
using SampleTemplate.Controllers;

namespace SampleTemplate.Controllers
{
    public class GameInfoController : Controller
    {
        static List<Game> selectedGame = new List<Game>();
        // GET: GameInfo
        public ActionResult Index()
        {
            return View();
        }
    }
}
    