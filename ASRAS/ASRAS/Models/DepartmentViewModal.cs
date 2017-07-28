using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASRAS.Models
{
    public class DepartmentViewModal
    {
        public List<Department> DeptList = new List<Department>();
        //public string Dname { get; set; }
        //public Double D_id { get; set; }
        public Double SelectedDepartmentID { get; set; }
        public IEnumerable<SelectListItem> DepartmentIEnum
        {
            get
            {
                return new SelectList(DeptList, "D_id", "Dname");
            }
        }
    }
}