using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Bson.Serialization;

namespace ASRAS.Models
{
    public class InstituteRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected IMongoCollection<User> _collection;

        public InstituteRepository()
        {
            //if any error
            //__client = new MongoClient("mongodb//localhost");
            _client = new MongoClient();
            _database = _client.GetDatabase("AcademicSenate");
            _collection = _database.GetCollection<User>("All_institutes");

            //Functions need to be added
        }
    }
}