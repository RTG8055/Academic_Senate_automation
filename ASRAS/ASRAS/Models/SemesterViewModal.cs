using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASRAS.Models
{
    public class SemesterViewModal
    {
        public List<Semester> SemesterList = new List<Semester>();
        public Double selectedSemesterID { get; set; }
        public IEnumerable<SelectListItem> SemesterIEnum
        {
            get
            {
                return new SelectList(SemesterList, "S_id", "S_id");
            }
        }
    }
}