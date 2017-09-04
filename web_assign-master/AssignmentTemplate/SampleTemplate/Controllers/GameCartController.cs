using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleTemplate.Models;

namespace SampleTemplate.Controllers
{
    public class GameCartController : Controller
    {
        DAO dao = new DAO();
        static List<Game1> selectedGames = new List<Game1>();
        static List<ItemModel> selectedItems = new List<ItemModel>();

        decimal totalPrice = 0.0m;
        decimal totalPriceGame = 0.0m;
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGame(FormCollection form)
        {
            List<Game1> list = dao.ShowAllGames1();
            bool found = false, found1 = false;

            for (int i = 0; i < list.Count && found1 == false; i++)
            {
                if (list[i].Title == form["title"])
                {
                    list[i].Quantity = int.Parse(form["quantity"]);
                    selectedGames.Add(list[i]);
                    found1 = true;
                }
            }
            for (int i = 0; i < selectedItems.Count && found == false; i++)
            {
                if (selectedItems[i].ItemId == form["isbn"])
                {
                    selectedItems[i].Quantity = selectedItems[i].Quantity + int.Parse(form["quantity"]);
                    found = true;
                    found1 = true;
                }
            }

            return RedirectToAction("ViewCart");
        }
        [HttpPost]
        public ActionResult RemoveItem(FormCollection form)
        {
            bool found = false;
            ItemModel item;

            for (int i = 0; i < selectedItems.Count && found == false; i++)
            {

                if (selectedItems[i].ItemId == form["id"])
                {
                    item = selectedItems[i];
                    if (item.Quantity > 1)
                    {
                        item.Quantity = item.Quantity - 1;
                        item.TotalPrice = item.TotalPrice - item.Price;
                    }
                    else
                    {
                        selectedItems.Remove(item);
                    }
                    found = true;
                }
            }
            foreach (var item1 in selectedItems)
            {
                totalPrice = totalPrice + item1.TotalPrice;
            }
            ViewBag.TransactionPrice = totalPrice;

            return RedirectToAction("ViewCart");
        }

        public ActionResult ClearAll()
        {
            selectedGames.Clear();
            selectedItems.Clear();
            return RedirectToAction("ViewCart");
        }

        public ActionResult ViewCart()
        {
            foreach (Game1 game in selectedGames)
            {
                ItemModel item = new ItemModel();

                totalPriceGame = totalPriceGame + game.Quantity * game.Price;
                //item.ItemId = game.ID;
                item.Title = game.Title;
                item.Quantity = game.Quantity;
                item.Price = game.Price;
                item.TotalPrice = totalPriceGame;
                selectedItems.Add(item);

            }
            foreach (var item in selectedItems)
            {
                totalPrice = totalPrice + item.TotalPrice;
            }
            ViewBag.TransactionPrice = totalPrice;
            //To remove from the selected books to avoid adding them in selected items again and again
            selectedGames.Clear();
            return View(selectedItems);
        }

        public ActionResult CheckOut()
        {

            if (selectedItems.Count > 0)
            {
                foreach (ItemModel item in selectedItems)
                {
                    totalPrice = totalPrice + item.TotalPrice;
                }
            }
            dao.AddTransaction(Session.SessionID, DateTime.Now, totalPrice, Session["email"].ToString());
            foreach (ItemModel item in selectedItems)
            {
                dao.AddTransactionItem(Session.SessionID, item);

            }

            Session.Clear();
            return View();
        }
    }
}