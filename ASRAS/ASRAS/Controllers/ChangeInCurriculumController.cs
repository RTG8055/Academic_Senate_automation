using ASRAS.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Word = Microsoft.Office.Interop.Word;
using System.Web.Mvc;

namespace ASRAS.Controllers
{
    public class ChangeInCurriculumController : Controller
    {
        public ActionResult Index()
        {
            TempData["UserName3"] = TempData["UserName2"];
            ViewData["Uname"] = TempData["UserName2"];
            ViewBag.Uname = TempData["UserName2"];
            return View();
        }

        public ActionResult Modify()
        {
            TempData["UserName4"] = TempData["UserName3"];
            ViewBag.Uname = TempData["UserName3"];
            return View("Modify");
        }

        public ActionResult AddNewSubject()
        {
            TempData["UserName4"] = TempData["UserName3"];
            ViewBag.Uname = TempData["UserName3"];
            return View("AddNewSubject");
        }

        public ActionResult RemoveSubject()
        {
            TempData["UserName4"] = TempData["UserName3"];
            ViewBag.Uname = TempData["UserName3"];
            return View("RemoveSubject");
        }

        public ActionResult GenerateDocument(string documentAbstract, string documentObjectives,string documentOutcomes, string documentMain, string documentReferences, string location)
        {
            Word.Application wordApplication;
            Word.Document wordDocument;
            wordApplication = new Word.Application();
            wordApplication.Visible = false;
            wordDocument = wordApplication.Documents.Add();

            wordDocument = DocumentGenerator.insert(wordDocument, "Abstract", documentAbstract);
            wordDocument = DocumentGenerator.insert(wordDocument, "Objectives", documentObjectives);
            wordDocument = DocumentGenerator.insert(wordDocument, "Outcomes", documentOutcomes);
            wordDocument = DocumentGenerator.insert(wordDocument, "Syllabus", documentMain);
            wordDocument = DocumentGenerator.insert(wordDocument, "References", documentReferences);
            DocumentGenerator.saveDocument(wordDocument, location);

            wordDocument.Close();
            wordApplication.Quit();

            return View("Modify");
        }
    }
}