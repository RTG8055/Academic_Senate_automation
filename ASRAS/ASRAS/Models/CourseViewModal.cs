using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASRAS.Models
{
    public class CourseViewModal
    {
        public List<Course> CourseList = new List<Course>();
        public Double SelectedCourseID { get; set; }
        //public string Cname { get; set; }
        //public Double C_id { get; set; }
        public IEnumerable<SelectListItem> CourseIEnum
        {
            get
            {
                return new SelectList(CourseList, "C_id", "Cname");
            }
        }
    }
}