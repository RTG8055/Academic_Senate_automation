using System.Collections.Generic;
using MongoDB.Bson;

namespace ASRAS
{
    public class User

    {
        public User()
        {
            this.Proposals = new List<Proposal>();
        }

        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string Designation { get; set; }

        public List<Proposal> Proposals { get; set; }

    }
    public class Proposal
    {
        public string Index { get; set; }
        public string Title { get; set; }
        public string Institute { get; set; }
        public string Dept { get; set; }
        public string Course{ get; set; }
        public string Semester { get; set; }
        public string Sub_type{ get; set; }
        public string Sub_code{ get; set; }
        public string Others_CC_text { get; set; }
        public string Others_CC_file { get; set; }
        public string Full_syll{ get; set; }
        public string Abstract { get; set; }
        public string Objectives{ get; set; }
        public string Outcome{ get; set; }
        public string References{ get; set; }
        public string Incl_sem { get; set; }
        public string Incl_sub_type { get; set; }
        public string Others_CR_text { get; set; }
        public string Others_CR_file { get; set; }

        public string Present_split{ get; set; }
        public string Proposed_split{ get; set; }
        public string Present_nomenclature { get; set; }
        public string New_nomenclature { get; set; }
        public string With_effect_from { get; set; }
        public string Modification_requested { get; set; }
        public string Present_eligibility { get; set; }
        public string Proposed_eligibility { get; set; }
        public string Others_CS_text { get; set; }
        public string Others_CS_file { get; set; }

        public string Proposed_cname{ get; set; }
        public string Adm_capacity{ get; set; }
        public string Proposed_curriculum{ get; set; }
        public string Proposed_distribution { get; set; }
    }
}