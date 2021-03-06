using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Controllers
{
    public class DerivedController : Controller
    {
        // GET: Derived
        public ActionResult Index()
        {
            ViewBag.Message = "Hi from the DerivedController";
            return View("MyView");
        }

        public ActionResult ProductOutput()
        {
            return Redirect("/Basic/Index");
        }
    }
}