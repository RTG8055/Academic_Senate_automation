using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASRAS.Models
{
    public class SubjectViewModal
    {
        public List<Subject> SubjectList = new List<Subject>();
        public double selectedSubjectID { get; set; }
        public IEnumerable<SelectListItem> SubjectIEnum
        {
            get
            {
                return new SelectList(SubjectList, "Sub_id", "Sub_name");
            }
        }
    }
}