using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
namespace FileUpload.Controllers
{
    using System.Web.Mvc;

    public class UploadController : Controller
    {
        // GET: Upload  
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]

        public void UploadFile(HttpPostedFileBase file)
        {

            try
            {
                int s = 0;
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), "abc");
                    file.SaveAs(_path);
                    s = 1;
                }
                if (s == 1)
                {
                    Debug.WriteLine("File Uploaded Successfully!!");

                }
                
            }
            catch
            {
                Debug.WriteLine("File upload failed!!");
            }

        }
    }
}