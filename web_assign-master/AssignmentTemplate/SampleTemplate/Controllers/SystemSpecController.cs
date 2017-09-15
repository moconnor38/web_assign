using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Data;
using SampleTemplate.Models;

namespace SampleTemplate.Controllers
{
    public class SystemSpecController : Controller
    {
        // GET: SystemSpec
        public ActionResult Index()
        {
            List<Systemreqs> reqs = new List<Systemreqs>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath(@"~/App_Data/specs.xml"));

            foreach (XmlNode node in xmlDoc.SelectNodes("/Spec/game"))
            {
                reqs.Add(new Systemreqs
                {
                    Title = node["Title"].InnerText,
                    Processor = node["Processor"].InnerText,
                    Memory = node["Memory"].InnerText,
                    Storage = node["Storage"].InnerText,
                    Video = node["Video"].InnerText
                });
            }
            return View(reqs);
        }
    }
}