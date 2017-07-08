using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Bson.Serialization;

namespace ASRAS.Models
{
    public class UserRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected IMongoCollection<User> _collection;

        public UserRepository()
        {
            //if any error
            //__client = new MongoClient("mongodb//localhost");
            _client = new MongoClient();
            _database = _client.GetDatabase("AcademicSenate");
            _collection = _database.GetCollection<User>("Users");
        }
        public string GetId(string Uname)
        {
            return this.Get(Uname).Id.ToString();
        }
        public User InsertPost(User contact)
        {
            this._collection.InsertOneAsync(contact);
            return this.Get(contact.UserName);
            //return contact;
        }
        public List<User> SelectAll()
        {
            var query = this._collection.Find(new BsonDocument()).ToListAsync();
            return query.Result;
        }
        public List<User> Filter(string jsonQuery)
        {
            var queryDoc = new BsonDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
            return _collection.Find<User>(queryDoc).ToList();
        }

        public User Get(string Uname)
        {
            return this._collection.Find(new BsonDocument { { "UserName", Uname } }).FirstAsync().Result;
        }
        public User UpdatePost(string id, User U)
        {
            U.Id = new ObjectId(id);

            var filter = Builders<User>.Filter.Eq(s => s.Id, U.Id);
            this._collection.ReplaceOneAsync(filter, U);
            return this.Get(U.UserName);
        }
    }
}