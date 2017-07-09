﻿using System;
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
        protected UserRepository _repository;

        public LoginController()
        {
            _repository = new UserRepository();
        }
          
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Clicked(string username, string password)
        {


            //creating a user record
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
                        Full_syll= null,
                        Abstract= null,
                        Objectives= null,
                        Outcome= null,
                        References= null,
                        Incl_sem= null,
                        Incl_sub_type= null,
                        Present_split= null,
                        Proposed_split= null,
                        Proposed_cname= null,
                        Adm_capacity= null,
                        Proposed_curriculum= null
                    }
                }
            };

            //Working Code for insertion
            User a = _repository.InsertPost(u);
            ViewBag.Result = a.ToJson().ToString();

            //working code
            //---------------------
            /*
            string res = null;
            List<User> a = _repository.SelectAll();
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
            List<User> a = _repository.Filter("{UserName: 'RSingh', Pass:'12345678'}");
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
            User curr_user = null;
            List<User> Hits = _repository.Filter("{UserName: '" + Entered_Uname + "', Pass: '" + Entered_Pass + "'}");
            if (Hits == null)
                ViewBag.Result = "Error!!";
            else
            {
                foreach (User s in Hits)
                {
                    if (s.ToJson().ToString() == null)
                        ViewBag.Result = "Invalid Login";
                    else
                    {
                        ViewBag.Result = "Welcome " + s.Name.ToString();
                        curr_user = s;
                    }
                }
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
            return View("Login");
        }
    }
}