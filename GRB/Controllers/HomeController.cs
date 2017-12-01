using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GRB.Models;
using System.Data.Entity;

namespace GRB.Controllers
{
    public class HomeController : Controller
    {
        private GoaRehabEntities db = new GoaRehabEntities();
        public ActionResult Index()
        {
            NewsTbl ntb = new NewsTbl();
            var id = 1;
            var stst = "Activated";
            ViewBag.res = db.GoaRehabTbls.Find(id);
            return View(db.NewsTbls.Where(nt => nt.N_Status == stst).ToList());
        }

        public ActionResult InnerCircle()
        {
            return View();
        }

        public ActionResult About()
        {
            var id = 1;
            ViewBag.info = db.GoaRehabTbls.Find(id);
            ViewBag.Message = "Your application description page."; 
            return View();
        }

        public ActionResult ContactTech()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}