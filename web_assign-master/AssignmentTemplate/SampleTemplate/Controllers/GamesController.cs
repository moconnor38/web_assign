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
            //List<Game1> gamelist = dao.ShowAllGames();
            {
                new Game{ Developer="Arkane",Title="Prey", DatePublished= new DateTime(2017, 12, 03), Publisher="Bethesda", Price=34.99m,GameImage="PreySmall.jpg" },
                new Game{ Developer="Blizzard",Title="Overwatch", DatePublished= new DateTime(2016, 11, 01), Publisher="Activision", Price=44.99m,GameImage="Overwatch.jpg" },
                new Game{ Developer="From Software",Title="Dark Souls 2", DatePublished= new DateTime(2014, 04, 25), Publisher="Bandai", Price=24.99m,GameImage="Darksouls2.jpg" },
                new Game{ Developer="Blizzard",Title="Diablo3", DatePublished= new DateTime(2012, 05, 15), Publisher="Activision", Price=19.99m,GameImage="Diablo3.jpg" },
                new Game{ Developer="Bungie",Title="Destiny2", DatePublished= new DateTime(2017, 10, 24), Publisher="Activision", Price=49.99m,GameImage="Destiny2.jpg" },
                new Game{ Developer="Bethesda",Title="Fallout 4", DatePublished= new DateTime(2015, 11, 10), Publisher="Bethesda", Price=49.99m,GameImage="Fallout4.jpg" },
                new Game{ Developer="Square Enix",Title="Final Fantasy XIV", DatePublished= new DateTime(2013, 08, 27), Publisher="Square Enix", Price=19.99m,GameImage="FFXIV.jpg" },
                new Game{ Developer="Riot",Title="League of Legends", DatePublished= new DateTime(2009, 10, 27), Publisher="Riot Games", Price=24.99m,GameImage="League.jpg" },
                new Game{ Developer="BioWare",Title="Mass Effect Andromeda", DatePublished= new DateTime(2017, 03, 21), Publisher="Electronic Arts", Price=39.99m,GameImage="Masseffect.jpg" },
                new Game{ Developer="Bethesda",Title="Skyrim", DatePublished= new DateTime(2016, 10, 27), Publisher="Bethesda", Price=39.99m,GameImage="Skyrim.jpg" },
                new Game{ Developer="Bungie",Title="Titanfall 2", DatePublished= new DateTime(2017, 10, 24), Publisher="Activision", Price=49.99m,GameImage="Titansmall.jpg" },
                new Game{ Developer="CD Projekt Red",Title="The Witcher 3", DatePublished= new DateTime(2015, 05, 19), Publisher="Warner Bros Interactive Entertainment", Price=19.99m,GameImage="Witcher.jpg" },
            };
            //List<int> quantityList = new List<int>() { 1, 2, 3, 4, 5 };
            //ViewBag.Quantity = quantityList;
            return View(gamelist);
        }
    }
}