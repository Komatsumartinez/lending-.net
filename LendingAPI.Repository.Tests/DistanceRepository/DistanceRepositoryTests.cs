using LendingAPI.Business;
using LendingAPI.Business.Models;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using Moq;

namespace LendingAPI.Repository.Tests.DistanceRepositorys
{
    public class DistanceRepositoryTests
    {
        protected DistanceRepository DistanceRepository;
        protected Mock<IMongoCollection<DistancesCollection>> MockCollection;
        protected Mock<IAsyncCursor<DistancesCollection>> mockCursor;

        public DistanceRepositoryTests()
        {
            DistanceRepository = new DistanceRepository("mongodb://localhost:27017", "LendingDB");
            MockCollection = new Mock<IMongoCollection<DistancesCollection>>(); 
            mockCursor = new Mock<IAsyncCursor<DistancesCollection>>();
        }
    }
}