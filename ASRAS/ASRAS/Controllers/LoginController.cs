using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;


using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using ASRAS.Models;

namespace ASRAS.Controllers
{
    public class LoginController : Controller
    {
        protected UserRepository _repositoryUser;

        protected void SetLayout()
        {
            ViewBag.Layout = "~/Views/Shared/_ALayout.cshtml";
            return;
        }

        public LoginController()
        {
            SetLayout();
            _repositoryUser = new UserRepository();
        }
          
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Clicked(string username, string password)
        {


            //creating a user record
            /*
            var u = new User()
            {
                Name = "Yash",
                UserName = "YMAl",
                Pass = "12345",
                Designation = "HOD",
                Proposals = new List<Proposals>()
                {
                    new Proposals()
                    {
                        Index = null,
                        Title =  null,
                        Institute= null,
                        Dept= null,
                        Course= null,
                        Semester= null,
                        Sub_type= null,
                        Sub_code= null,
                        Others_CC_text = null,
                        Others_CC_file=null,
                        Full_syll= null,
                        Abstract= null,
                        Objectives= null,
                        Outcome= null,
                        References= null,
                        Incl_sem= null,
                        Incl_sub_type= null,
                        Others_CR_text=null,
                        Others_CR_file=null,
                        Present_split= null,
                        Proposed_split= null,
                        Present_nomenclature = null,
                        New_nomenclature = null,
                        With_effect_from=null,
                        Modification_requested =null,
                        Present_eligibility = null,
                        Proposed_eligibility = null,
                        Others_CS_text = null,
                        Others_CS_file = null,
                        Proposed_cname= null,
                        Adm_capacity= null,
                        Proposed_curriculum= null,
                        Proposed_distribution = null
                    }
                }
            };
            */
            //Working COde for insertion
            //-----------
            //User a = _repositoryUser.InsertPost(u);
            //ViewBag.Result = a.ToJson().ToString();
            //-----------

            //working code
            //---------------------
            /*
            string res = null;
            List<User> a = _repositoryUser.SelectAll();
            foreach( User s in a)
            {
                if(res == null) 
                    res = s.ToJson().ToString();
                else
                    res = res + s.ToJson().ToString();
            }
            ViewBag.Result = res;
            */
            //---------------------


            //Working Code for querying
            //-----------------
            /*
            string res = null;
            List<User> a = _repositoryUser.Filter("{UserName: 'RSingh', Pass:'12345678'}");
            if (a == null)
                ViewBag.Result = "NotFound";
            else
            {
                foreach (User s in a)
                {
                    if (res == null)
                        res = s.ToJson().ToString();
                    else
                        res = res + s.ToJson().ToString();
                }
                if (res == null)
                    ViewBag.Result = "NotFound";
                else
                    ViewBag.Result = res;
            }
            ViewBag.Result = a.ToString();

            ViewBag.xyz = a.ToJson().ToString();
            */

            //-------------------
            string Entered_Uname = username;
            string Entered_Pass = password;
            if (Entered_Uname == null || Entered_Pass == null)
                //return JavaScript(alert("please enter username and password"));
                return Content("<script language = 'javascript' type = 'text/javascript'>alert('please enter username and password'); window.location.href = 'login'</script>");
            User curr_user = null;
            try
            {
                List<User> Hits = _repositoryUser.Filter("{UserName: '" + Entered_Uname + "', Pass: '" + Entered_Pass + "'}");
                if (Hits == null)
                    //ViewBag.Result = "Error!!";
                    return Content("<script language = 'javascript' type = 'text/javascript'>alert('ERROR!!'); window.location.href = 'login'</script>");
                else
                {
                    foreach (User s in Hits)
                    {
                        if (s.ToJson().ToString() == null)
                            //ViewBag.Result = "Invalid Login";
                            return Content("<script language = 'javascript' type = 'text/javascript'>alert('ERROR!!'); window.location.href = 'login'</script>");
                        else
                        {
                            ViewBag.Result = "Welcome " + s.Name.ToString();
                            string UserName = s.UserName.ToString();
                            TempData["UserName"] = s.UserName;
                            return this.RedirectToAction("Index", "Main");
                            
                        }
                    }
                }
            }
            catch(Exception e)
            {
                string error = e.ToString();
                return Content("<script language = 'javascript' type = 'text/javascript'>alert('" + e + "'); window.location.href = 'login'</script>");
            }

            /*
            if (username.Equals("robby") && password.Equals("singh"))
            {
               // ViewBag.Result = "Right";

            }
            else
            {
                //ViewBag.Result = "Wrong";
            }*/
            return RedirectToAction("Index", "Main");
        }
    }
}