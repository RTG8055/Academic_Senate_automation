using ASRAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASRAS.Controllers
{
    public class PreviewController : Controller
    {
        public ActionResult Preview(/*string documentAbstract, string documentObjectives, string documentOutcomes, string documentMain, string documentReferences*/Models.FormData formData)
        {
            Proposal proposal = new Proposal();

            proposal.Abstract = documentAbstract;
            proposal.Objectives = documentObjectives;
            proposal.Outcome = documentOutcomes;
            proposal.Full_syll = documentMain;
            proposal.References = documentReferences;

            ProposalRepository proposalRepository = new ProposalRepository();
            proposalRepository.InsertProposal(proposal);

            TempData["DataSet"] = proposal;

            return View();
        }
    }
}