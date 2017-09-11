using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace SampleTemplate.Controllers
{
    public class RSSController : Controller
    {
        public ActionResult Index()
        {
            string url = "http://feeds.ign.com/ign/pc-all?format=xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(url);
            XmlNode rootNode = xml.DocumentElement;
            XmlNode channel = rootNode.FirstChild;
            XmlNodeList list = channel.ChildNodes;
            ViewBag.Title = channel.FirstChild.InnerText;
            ViewBag.List = list;
            return PartialView("/Views/RSS/Index.cshtml", list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}