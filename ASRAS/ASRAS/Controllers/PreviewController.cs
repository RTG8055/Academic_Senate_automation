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
        public ActionResult Preview(FormModal formModal)
        {
            Proposal proposal = formModal.proposal;
            Institute i = (Institute) Session["Institute"];
            proposal.Institute = i.Name;
            try
            {
                foreach (Department d in i.Departments)
                {
                    if (d.D_id.ToString() == proposal.Dept)
                    {
                        proposal.Dept = d.Dname;
                        if (proposal.Course == null)
                        {
                            continue;
                        }
                        foreach (Course c in d.Courses)
                        {

                            if (c.C_id.ToString() == proposal.Course)
                            {
                                proposal.Course = c.Cname;
                                if (proposal.Semester == null)
                                    continue;
                                //foreach(Semester s in c.Semesters)
                                //{
                                //    if(s.S_id == proposal.Semester)
                                //    {
                                //        proposal.Semester = s.S_id;
                                //        if(proposal.Sub_type == "1")

                                //        }
                                //    }
                                //}
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
            }
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
        public ActionResult Submit()
        {
            insertIntoDatabase();
            return RedirectToAction("Index", "Main");
        }
    }
}