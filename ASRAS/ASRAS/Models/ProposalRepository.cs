using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;

namespace ASRAS.Models
{
    public class ProposalRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected IMongoCollection<Proposal> _collection;

        public ProposalRepository()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("AcademicSenate");
            _collection = _database.GetCollection<Proposal>("Proposals");
        }

        public void InsertProposal(Proposal p)
        {
            this._collection.InsertOneAsync(p);
        }

        public List<Proposal> GetProposals(string Institute)
        {
            string query = "{Institute :'" + Institute + "'}";
            var QueryB = new BsonDocument(BsonSerializer.Deserialize<BsonDocument>(query));
            return _collection.Find<Proposal>(QueryB).ToList();
        }
    }
}