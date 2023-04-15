using LendingAPI.Business.Models;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingAPI.Business.Tests.DistanceServiceTests.GetDistanceByZipAsync
{
    public class GetDistanceByZipAsyncTests : DistanceServiceTests
    {
        [Fact]
        public async Task Will_Return_Zip_Information_By_Id()
        {
            #region Variables            
            var expectedData = new DistancesCollection { City = "Anaheim", Id = new ObjectId("643ac1892fd11d97d4829d19"), LAT = 33.844983, LNG = -117.952151, ZIP = "9121" };
               
            #endregion

            #region Setup
            MockDistanceRepository.Setup(s => s.GetDistanceByZips("9121"))
             .ReturnsAsync(expectedData)
             .Verifiable();
            #endregion

            #region Call
            var result = await Service.GetDistanceByZipAsync("9121");
            #endregion

            #region Verify
            MockDistanceRepository.Verify(v => v.GetDistanceByZips("9121"), Times.Once);
            #endregion

            #region Assert
            Assert.IsType<DistanceDto>(result);
            Assert.Equal(expectedData.City, result.City);
            Assert.Equal(expectedData.LAT, result.LAT);
            Assert.Equal(expectedData.LNG, result.LNG);
            Assert.Equal(expectedData.ZIP, result.ZIP);
            #endregion
        }

        [Fact]
        public async Task Will_Return_Not_Found_Zip_Information_By_Id()
        {
            #region Variables            
            var expectedData = new DistancesCollection {};

            #endregion

            #region Setup
            MockDistanceRepository.Setup(s => s.GetDistanceByZips("75432"))
             .ReturnsAsync(expectedData)
             .Verifiable();
            #endregion

            #region Call
            var result = await Service.GetDistanceByZipAsync("9121");
            #endregion

            #region Verify
            MockDistanceRepository.Verify(v => v.GetDistanceByZips("9121"), Times.Once);
            #endregion

            #region Assert            
            Assert.Null(result);
            #endregion
        }
    }
}
