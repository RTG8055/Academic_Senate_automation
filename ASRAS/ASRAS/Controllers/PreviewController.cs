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
            //Proposal proposal = new Proposal();

            Debug.WriteLine("date: "+p.DateofBOS);

            //proposal.Abstract = documentAbstract;
            //proposal.Objectives = documentObjectives;
            //proposal.Outcome = documentOutcomes;
            //proposal.Full_syll = documentMain;
            //proposal.References = documentReferences;

            //ProposalRepository proposalRepository = new ProposalRepository();
            //proposalRepository.InsertProposal(proposal);

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