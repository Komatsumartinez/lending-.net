using LendingAPI.Business.Models;
using LendingAPI.Repository;
using LendingAPI.Repository.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace LendingAPI.Business
{
    public class DistanceRepository : IDistanceRepository
    {
        public MongoClient MongoClient { get; set; }
        public IMongoDatabase Database { get; set; }
        private IMongoCollection<DistancesCollection> Collection;
        public DistanceRepository(string connectionString, string databaseName)
        {
            MongoClient = new MongoClient(connectionString);
            Database = MongoClient.GetDatabase(databaseName);
            Collection = Database.GetCollection<DistancesCollection>("distances");
        }
        public async Task<DistancesCollection> GetDistanceByZips(string zipCode)
        {
            return await Collection.FindAsync(new BsonDocument { { "ZIP", zipCode } }).Result.FirstAsync(); ;
        }

        public async Task<List<DistancesCollection>> GetAllZips()
        {            
            return await Collection.FindAsync(new BsonDocument { }).Result.ToListAsync(); ;
        }
    }
}