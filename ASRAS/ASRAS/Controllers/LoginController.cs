using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASRAS.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Clicked(string username, string password)
        {
            if (username.Equals("robby") && password.Equals("singh"))
            {
                ViewBag.Result = "Right";
            }
            else
            {
                ViewBag.Result = "Wrong";
            }


            return View("Login");
        }
    }
}