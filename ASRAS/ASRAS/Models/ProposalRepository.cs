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
        public Double getProposalId(Proposal p)
        {
            Double P_id = 1;
            var all = this._collection.Find(new BsonDocument()).ToListAsync();

            foreach (Proposal tem_p in all.Result)
            {
                if(tem_p.P_id>P_id)
                {
                    P_id = tem_p.P_id;
                }
            }
            P_id = P_id + 1;
            return P_id;
        }
        public void InsertProposal(Proposal p)
        {
            //p.P_id = getProposalId(p);
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