﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleTemplate.Models;
namespace SampleTemplate.Controllers
{
    public class MemberPageController : Controller
    {
        DAO dao = new DAO();

        // GET: MemberPage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToLibrary(string email, string gamename)
        {
            dao.AddToLibrary(email, gamename);
            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult DisplayLibraryGames(string email)
        {

            List<Game> libraryList = dao.ShowLibraryGames(email);

            return View("~/Views/MemberPage/Index.cshtml", libraryList);
        }
    }
}