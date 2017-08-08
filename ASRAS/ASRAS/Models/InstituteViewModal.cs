using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using System.Web.Mvc;

namespace ASRAS.Models
{
    public class InstituteViewModal
    {
        public List<Institute> InsList = new List<Institute>();
        //public string InsName { get; set; }
        public Double SelectedInstituteID { get; set; }
        public IEnumerable<SelectListItem> InstituteIEnum
        {
            get
            {
                return new SelectList(InsList, "Ins_id", "Name");
            }
        }

        public Proposal proposal { get; set; }
    }
}