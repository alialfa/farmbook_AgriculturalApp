using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using FarmBook_v7.Models;

/* The Home contoller is a default MVC4 class that was customed in its inherent views
 * that relate to the home page, our contact details & mission statement */
 
namespace FarmBook_v7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Fostering Farming & Community Development";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "[Mission Statement]";

            return View();
        }

        public ActionResult Contact()
        {
           //ViewBag.Message = "As @ FarmBook";

            return View();
        }

    }
}
