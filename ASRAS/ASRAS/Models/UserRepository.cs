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
            //Returns the ID for the username passed
            return this.Get(Uname).Id.ToString();
        }
        public User InsertPost(User contact)
        {
            //inserts the user passed in the users collection
            this._collection.InsertOneAsync(contact);
            return this.Get(contact.UserName);
            //return contact;
        }
        /*public User UpdateProposals(string Uname, List<Proposal> newProposals)
        {
            //pass a new list of proposals(modify the proposal to be updated and pass the rest as the same) and the username of the user who needs to be modified
            //returns the old user with modifications
            User U = Get(Uname);
            U.Proposals = newProposals;
            return UpdateUser(U);


        }*/
        /*public List<Proposal> GetProposals(string Uname)
        {
            //get all the proposals of a particular user can be fetched by passing the username of the user
            User U = this._collection.Find(new BsonDocument { { "UserName", Uname } }).FirstAsync().Result;
            return U.Proposals;
        }*/
        public List<User> SelectAll()
        {
            //for quering use this function to fetch a list of all users in the collection and then loop through to find the required
            var query = this._collection.Find(new BsonDocument()).ToListAsync();
            return query.Result;
        }
        public List<User> Filter(string jsonQuery)
        {
            //pass a json query and get the list of users matching the query
            var queryDoc = new BsonDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
            return _collection.Find<User>(queryDoc).ToList();
        }

        public User Get(string Uname)
        {
            //a function that takes Username as a parameter and returns the corresponding user object from the database
            return this._collection.Find(new BsonDocument { { "UserName", Uname } }).FirstAsync().Result;
        }
        public User UpdateUser(User U)
        {
            //function to update a user record using: params: id of the to be edited user and the details of the new user in a user object
            U.Id = new ObjectId(GetId(U.UserName));

            var filter = Builders<User>.Filter.Eq(s => s.Id, U.Id);
            this._collection.ReplaceOneAsync(filter, U);
            return U;
        }
    }
}