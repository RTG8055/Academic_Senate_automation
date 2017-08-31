using System.Web.Mvc;
//using Word = Microsoft.Office.Interop.Word;
using ASRAS.Models;

namespace ASRAS.Controllers
{
    public class ChangeInRegulationsController : Controller
    {
        // GET: ChangeInRegulations
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeTimeScheme()
        {
            TempData["UserName4"] = TempData["UserName3"];
            ViewBag.Uname = TempData["UserName3"];
            return View("ChangeTimeScheme");
        }

        public ActionResult ChangeAssessmentScheme()
        {
            TempData["UserName4"] = TempData["UserName3"];
            ViewBag.Uname = TempData["UserName3"];
            return View("ChangeAssessmentScheme");
        }

        public ActionResult ChangeEligibilityCriteria()
        {
            TempData["UserName4"] = TempData["UserName3"];
            ViewBag.Uname = TempData["UserName3"];
            return View("ChangeEligibilityCriteria");
        }

        public ActionResult ChangeNomenclature()
        {
            TempData["UserName4"] = TempData["UserName3"];
            ViewBag.Uname = TempData["UserName3"];
            return View("ChangeNomenclature");
        }

        public ActionResult ChangePromotionCriteria()
        {
            TempData["UserName4"] = TempData["UserName3"];
            ViewBag.Uname = TempData["UserName3"];
            return View("ChangePromotionCriteria");
        }

        //public ActionResult GenerateDocument(string documentPresentEvaluation, string documentProposedEvaluation, string location)
        //{
        //    Word.Application wordApplication;
        //    Word.Document wordDocument;
        //    wordApplication = new Word.Application();
        //    wordApplication.Visible = false;
        //    wordDocument = wordApplication.Documents.Add();

        //    wordDocument = DocumentGenerator.insert(wordDocument, "Present Evaluation", documentPresentEvaluation);
        //    wordDocument = DocumentGenerator.insert(wordDocument, "Proposed Evaluation", documentProposedEvaluation);
        //    DocumentGenerator.saveDocument(wordDocument, location);

        //    wordDocument.Close();
        //    wordApplication.Quit();

        //    return View("ChangeTimeScheme");
        //}
    }
}