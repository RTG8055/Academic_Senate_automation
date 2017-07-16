using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASRAS.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            TempData["UserName2"] = TempData["UserName"];
            ViewBag.Uname = TempData["UserName2"];
            return View();
        }
    }
}