using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public void ProductOutput()
        {
            if (Server.MachineName == "TINY")
            {
                Response.Redirect("/Basic/Index");
            } else
            {
                Response.Write("Controller: Derived, Action: ProduceOutput");
            }
        }
    }
}