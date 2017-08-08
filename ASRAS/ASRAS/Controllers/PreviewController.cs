using ASRAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace ASRAS.Controllers
{
    public class PreviewController : Controller
    {
        public ActionResult Preview(/*string documentAbstract, string documentObjectives, string documentOutcomes, string documentMain, string documentReferences,*/ Proposal p)
        {
            Debug.WriteLine("date: "+p.DateofBOS);

            TempData["DataSet"] = p;

            return View();
        }

        public void insertIntoDatabase()
        {
            Proposal p = (Proposal)TempData["AnotherDataSet"];
            Debug.WriteLine("entered insert function");
            Debug.WriteLine(p.Abstract);
            new ProposalRepository().InsertProposal(p);
        }
    }
}