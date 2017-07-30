using System.Collections.Generic;
using MongoDB.Bson;

namespace ASRAS
{
    public class User

    {

        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string Designation { get; set; }
        public string Institute { get; set; }

    }
    
}