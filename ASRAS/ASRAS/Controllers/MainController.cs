using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASRAS.Models;
//using ASRAS.Models.ProposalList;

namespace ASRAS.Controllers
{
    public class MainController : Controller
    {
        public ProposalList p = new ProposalList();
        public ActionResult Index()
        {
            //TempData["UserName2"] = TempData["UserName"];
            ViewBag.Uname = Session["UserName"];

            return View();
        }
        public ActionResult GetProposals(string Uname)
        {
            if(Uname != (string)Session["UserName"])
            {
                return Content("<script language = 'javascript' type = 'text/javascript'>alert('Sorry, Session Expired!!'); window.location.href = 'login'</script>");
            }
            
            string Curr_Institute = (string)Session["Institute"];
            List<Proposal> All_Proposals = new ProposalRepository().GetProposals(Curr_Institute);
            ProposalList p = new ProposalList();
            p.PList = All_Proposals;
            return View(p);
        }
    }
}