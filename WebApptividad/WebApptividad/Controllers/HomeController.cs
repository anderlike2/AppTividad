using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApptividad.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            ViewBag.Message = "Search.";

            return View();
        }

        public ActionResult Data()
        {
            ViewBag.Message = "Data.";

            return View();
        }

        public ActionResult GetInfo()
        {
            ViewBag.Message = "Get Info.";

            return View();
        }
    }
}