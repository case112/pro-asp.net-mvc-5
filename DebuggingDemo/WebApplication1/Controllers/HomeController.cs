using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int firstVal = 10;

            int secondVal = 5;
            int result = firstVal / secondVal;

            ViewBag.Message = "Welcome to asp.net mvc!";

            return View(result);
        }
    }
}