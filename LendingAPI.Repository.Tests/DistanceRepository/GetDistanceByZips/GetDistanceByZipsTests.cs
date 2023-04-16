using LendingAPI.Business.Models;
using LendingAPI.Repository.Tests.DistanceRepositorys;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingAPI.Repository.Tests.DistanceRepositorys.GetDistanceByZips
{
    public class GetDistanceByZipsTests: DistanceRepositoryTests
    {
        [Fact]
        public async Task Will_Found_Zip_Information_By_Id()
        {
            #region Variables
            var expectedData = new DistancesCollection
            { City = "Anaheim", Id = new ObjectId("643ac1892fd11d97d4829d19"), LAT = 33.84765, LNG = -117.9526, ZIP = "92801" };
            #endregion

            #region Setup            
            #endregion

            #region Call
            var result = await DistanceRepository.GetDistanceByZips("92801");
            #endregion

            #region Verify

            #endregion

            #region Assert
            Assert.IsType<DistancesCollection>(result);
            Assert.Equal(expectedData.City, result.City);
            Assert.Equal(expectedData.LAT, result.LAT);
            Assert.Equal(expectedData.LNG, result.LNG);
            Assert.Equal(expectedData.ZIP, result.ZIP);
            #endregion             
        }
    }
}
