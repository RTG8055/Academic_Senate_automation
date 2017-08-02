using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASRAS.Controllers
{
    public class ChangeInCourseStructureController : Controller
    {
        // GET: ChangeInCourseStructure
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IntroduceNewCourse()
        {
            TempData["UserName3"] = TempData["UserName2"];
            ViewData["Uname"] = TempData["UserName2"];
            ViewBag.Uname = TempData["UserName2"];
            return View();
        }

        public ActionResult ReviseCourseStructure()
        {
            TempData["UserName3"] = TempData["UserName2"];
            ViewData["Uname"] = TempData["UserName2"];
            ViewBag.Uname = TempData["UserName2"];
            return View();
        }
    }
}