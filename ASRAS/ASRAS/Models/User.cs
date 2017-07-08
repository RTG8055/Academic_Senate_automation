using System.Collections.Generic;
using MongoDB.Bson;

namespace ASRAS
{
    public class User

    {
        /*[ScaffoldColumn(false)]
        [BsonId]
        public ObjectId PostId { get; set; }
        /*
        [ScaffoldColumn(false)]
        public DateTime Date { get; set; }

        [Required]
        public string Title { get; set; }

        [ScaffoldColumn(false)]
        public string Url { get; set; }

        [Required]
        public string Summary { get; set; }

        [UIHint("WYSIWYG")]
        [AllowHtml]
        public string Details { get; set; }

        [ScaffoldColumn(false)]
        public string Author { get; set; }

        [ScaffoldColumn(false)]
        public int TotalComments { get; set; }

        [ScaffoldColumn(false)]
        public IList<Command> Comments { get; set; }*/

        public User()
        {
            this.Proposals = new List<Proposals>();
        }

        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string Designation { get; set; }

        public List<Proposals> Proposals { get; set; }

/*        ObjectId id = new ObjectId();
        MongoClient client = null;
        MongoServer server = null;
        MongoDatabaseBase database = null;
        MongoCollection UserDetailscollection = null;*/


    }
    public class Proposals
    {
        public string Index { get; set; }
        public string Title { get; set; }
        public string Institute { get; set; }
        public string Dept { get; set; }
        public string Course{ get; set; }
        public string Semester { get; set; }
        public string Sub_type{ get; set; }
        public string Sub_code{ get; set; }
        public string Full_syll{ get; set; }
        public string Abstract { get; set; }
        public string Objectives{ get; set; }
        public string Outcome{ get; set; }
        public string References{ get; set; }
        public string Incl_sem { get; set; }
        public string Incl_sub_type { get; set; }
        public string Present_split{ get; set; }
        public string Proposed_split{ get; set; }
        public string Proposed_cname{ get; set; }
        public string Adm_capacity{ get; set; }
        public string Proposed_curriculum{ get; set; }
    }
}