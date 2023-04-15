using LendingAPI.Business.Models;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingAPI.Business.Tests.DistanceServiceTests.GetAllZipsInfoAsync
{
    public class GetAllZipsInfoAsyncTests : DistanceServiceTests
    {
        [Fact]
        public async Task Will_Return_Zips_Information()
        {
            #region Variables            
            var expectedData = new List<DistancesCollection>
            {
                new DistancesCollection
                { City = "Anaheim", Id = new ObjectId("643ac1892fd11d97d4829d19"), LAT = 33.844983, LNG = -117.952151, ZIP = "9121" },
                new DistancesCollection
                { City = "Los Angeles", Id = new ObjectId("643ac1892fd11d97d4829d19"), LAT = 33.844983, LNG = -117.952151, ZIP = "93831" },
                new DistancesCollection
                { City = "New York", Id = new ObjectId("643ac1892fd11d97d4829d19"), LAT = 33.844983, LNG = -117.952151, ZIP = "87232" },

            };
            #endregion

            #region Setup
            MockDistanceRepository.Setup(s => s.GetAllZips())
             .ReturnsAsync(expectedData)
             .Verifiable();
            #endregion

            #region Call
            var results = await Service.GetAllZipsInfoAsync();
            #endregion

            #region Verify
            MockDistanceRepository.Verify(v => v.GetAllZips(), Times.Once);
            #endregion

            #region Assert
            Assert.IsType<List<DistanceDto>>(results);
            Assert.Equal(3, results.Count());
            #endregion
        }

        [Fact]
        public async Task Will_Return_Not_Found_Zips_Information()
        {
            #region Variables            
            var expectedData = new List<DistancesCollection>
            {
            };
            #endregion

            #region Setup
            MockDistanceRepository.Setup(s => s.GetAllZips())
             .ReturnsAsync(expectedData)
             .Verifiable();
            #endregion

            #region Call
            var results = await Service.GetAllZipsInfoAsync();
            #endregion

            #region Verify
            MockDistanceRepository.Verify(v => v.GetAllZips(), Times.Once);
            #endregion

            #region Assert
            Assert.IsType<List<DistanceDto>>(results);
            Assert.Empty(results);
            #endregion
        }
    }
}
