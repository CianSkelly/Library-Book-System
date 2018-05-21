using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryBookSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Phil & Cian About.";

            return View();
        }

        public ActionResult Book()
        {
            ViewBag.Message = "Your Book page.";

            return View();
        }

        public ActionResult LibUser()
        {
            ViewBag.Message = "Your Library User page.";

            return View();
        }
    }
}
