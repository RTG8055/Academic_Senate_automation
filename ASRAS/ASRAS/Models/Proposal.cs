using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASRAS.Models
{
    public class Proposal
    {
        public Double P_id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateofBOS { get; set; }

        public string UploadLink { get; set; }
        public string Index { get; set; }
        public string Title { get; set; }
        public string Institute { get; set; }
        public string Dept { get; set; }
        public string Course { get; set; }
        public string Semester { get; set; }
        public string Sub_type { get; set; }
        public string Sub_code { get; set; }
        public string Others_CC_text { get; set; }
        public string Others_CC_file { get; set; }
        public string Full_syll { get; set; }
        public string Abstract { get; set; }
        public string Objectives { get; set; }
        public string Outcome { get; set; }
        public string References { get; set; }
        public string Incl_sem { get; set; }
        public string Incl_sub_type { get; set; }
        public string Others_CR_text { get; set; }
        public string Others_CR_file { get; set; }

        public string Present_split { get; set; }
        public string Proposed_split { get; set; }
        public string Present_nomenclature { get; set; }
        public string New_nomenclature { get; set; }
        public string With_effect_from { get; set; }
        public string Modification_requested { get; set; }
        public string Present_eligibility { get; set; }
        public string Proposed_eligibility { get; set; }
        public string Others_CS_text { get; set; }
        public string Others_CS_file { get; set; }

        public string Proposed_cname { get; set; }
        public string Adm_capacity { get; set; }
        public string Proposed_curriculum { get; set; }
        public string Proposed_distribution { get; set; }
    }
}