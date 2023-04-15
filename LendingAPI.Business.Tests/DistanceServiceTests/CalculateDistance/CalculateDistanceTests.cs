using LendingAPI.Business.Models;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingAPI.Business.Tests.DistanceServiceTests.CalculateDistance
{
    public class CalculateDistanceTests : DistanceServiceTests
    {
        [Fact]
        public async Task Will_Return_Distance_Calculated()
        {
            #region Variables            
            var calculateDistance = new CalculatedDistance { FromZip = "9121", ToZip = "93831", DistanceInMiles=0 };
            var zipInfoFrom = new DistancesCollection { City = "Anaheim", Id = new ObjectId("643ac1892fd11d97d4829d19"), LAT = 33.844983, LNG = -117.952151, ZIP = "9121" };
            var zipInfoTo = new DistancesCollection { City = "Los Angeles", Id = new ObjectId("643ac1892fd11d97d4829d19"), LAT = 31.844983, LNG = -109.952151, ZIP = "93831" };
            #endregion

            #region Setup      
            MockDistanceRepository.Setup(s => s.GetDistanceByZips("9121"))
             .ReturnsAsync(zipInfoFrom)
             .Verifiable();

            MockDistanceRepository.Setup(s => s.GetDistanceByZips("93831"))
             .ReturnsAsync(zipInfoTo)
             .Verifiable();

            #endregion

            #region Call
            var results = await Service.CalculateDistance(calculateDistance);
            #endregion

            #region Verify
            MockDistanceRepository.Verify(v => v.GetDistanceByZips("9121"), Times.Once);
            MockDistanceRepository.Verify(v => v.GetDistanceByZips("93831"), Times.Once);
            #endregion

            #region Assert
            Assert.IsType<CalculatedDistance>(results);
            Assert.Equal(779.4885499806808, results.DistanceInMiles);
            #endregion
        }
    }
}
