using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseMange.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "You description page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "You contact page.";
            return View();
        }
        [ChildActionOnly]

        public ActionResult Navbar()
        {
            var site = new websiteInfo();
            ViewBag.Site = site;
            return PartialView("/Views/Shared/Navbar.cshtml");
        }
    }
}
