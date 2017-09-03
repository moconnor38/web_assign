using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleTemplate.Models;

namespace SampleTemplate.Controllers
{
    public class GamesController : Controller
    {
        DAO dao = new DAO();
        public ActionResult Index()
        {
            List<Game> gamelist = new List<Game>()
            //List<Game1> gamelist = dao.ShowAllGames1();
            {
                new Game{ Developer="Arkane",Title="Prey", DatePublished= new DateTime(2017, 12, 03), Publisher="Bethesda", Price=34.99m,GameImage="xx.png" },
                new Game{ Developer="Blizzard",Title="Overwatch", DatePublished= new DateTime(2016, 11, 01), Publisher="ActivisionBlizzard", Price=45,GameImage="xx.png" },
                new Game{ Developer="Valve",Title="Half-Life", DatePublished= new DateTime(2016, 01, 03), Publisher="Valve", Price=29.98m,GameImage="xx.png" },
                new Game{ Developer="Crate Entertainment",Title="Grim Dawn", DatePublished= new DateTime(2017, 01, 05), Publisher="Crate Entertainment", Price=36,GameImage="xx.png" },
            };
            //List<int> quantityList = new List<int>() { 1, 2, 3, 4, 5 };
            //ViewBag.Quantity = quantityList;
            return View(gamelist);
        }
    }
}