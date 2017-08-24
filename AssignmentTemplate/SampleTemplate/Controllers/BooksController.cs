using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleTemplate.Models;

namespace SampleTemplate.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            List<Book> booklist = new List<Book>()
            {
                new Book{ ISBN="26347264",Title="C++ Programming", DatePublished= new DateTime(2015, 12, 03), Publisher="Wiley", Price=34.99m,BookImage="CPlus.png" },
                new Book{ ISBN="134384739",Title="Java Programming", DatePublished= new DateTime(2016, 11, 01), Publisher="Pearson", Price=45,BookImage="Java.png" },
                new Book{ ISBN="346346364",Title="Beginning Programming for Dummies", DatePublished= new DateTime(2016, 01, 03), Publisher="OReilly", Price=29.98m,BookImage="Programming.png" },
                new Book{ ISBN="174854855",Title="Python Programming", DatePublished= new DateTime(2017, 01, 05), Publisher="Prentice Hall", Price=36,BookImage="Python.png" },
            };
            return View(booklist);
        }
    }
}