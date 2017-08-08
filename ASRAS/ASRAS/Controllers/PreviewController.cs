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
        public ActionResult Preview(Proposal proposal)
        {
            TempData["DataSet"] = proposal;

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