﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleTemplate.Models;

namespace SampleTemplate.Controllers
{
    public class UserController : Controller
    {
        DAO dao = new DAO();
        // GET: User
        public ActionResult Index()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            int count = 0;
            if (ModelState.IsValid)
            {
                count = dao.Insert(user);
                //Response.Write(dao.message);
                if (count == 1)
                    ViewBag.Status = "User is created successfully.";
                else
                {
                    ViewBag.Status = "Error! " + dao.message;
                }
                return View("Status");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
           
        }

        [HttpPost]
       public ActionResult Login(UserModel user)
        {
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            ModelState.Remove("ComparePassword");
            
            if (ModelState.IsValid)
            {
                user.FirstName = dao.CheckLogin(user);
                if (user.FirstName != null)
                {
                    Session["name"] = user.FirstName;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Status = "Error! " + dao.message;
                    return View("Status");
                }
                
            }
            else return View(user);
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return View("../Home/Index");
        }
    }
}