using CraigslistbyMic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CraigslistbyMic.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.AutomotiveSub = db.SubCatagories.Where(f => f.CatagoryId == 3).ToList();
            ViewBag.ElectronicsSub = db.SubCatagories.Where(f => f.CatagoryId == 2).ToList();
            ViewBag.FurnitureSub = db.SubCatagories.Where(f => f.CatagoryId == 1).ToList();
            return View();
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