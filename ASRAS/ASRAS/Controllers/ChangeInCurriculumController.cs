using ASRAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASRAS.Controllers
{
    public class ChangeInCurriculumController : Controller
    {
        protected InstituteRepository _repository;

        public ChangeInCurriculumController()
        {
            _repository = new InstituteRepository();
        }

        // GET: ChangeInCurriculum
        public ActionResult Index()
        {
            TempData["UserName3"] = TempData["UserName2"];
            ViewData["Uname"] = TempData["UserName3"].ToString();
            return View();
        }
        [HttpPost]
        public ActionResult UpdateInstitute(int Institutes)
        {
            ViewBag.curr_ins = Institutes;
            return View("Modify");
        }
        public ActionResult Modify()
        {


            List<String> All_ins = _repository.GetInstitutes();
            TempData["Ins"] = All_ins;
            ViewData["Ins"] = All_ins;
            List<SelectListItem> listInstitutes = new List<SelectListItem>();
            foreach (string i in All_ins)
            {
                listInstitutes.Add(new SelectListItem { Text = i, Value = i });
            }
            ViewBag.ListItem = listInstitutes;
            return View("Modify");
        }
    }
}