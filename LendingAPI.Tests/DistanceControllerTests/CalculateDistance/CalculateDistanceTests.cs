using LendingAPI.Business.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingAPI.Tests.DistanceControllerTests.CalculateDistance
{
    public class CalculateDistanceTests : DistanceControllerTests
    {
        [Fact]
        public void Will_Return_All_Zip_Information()
        {
            #region Variables    
            var calculateDistance = new CalculatedDistance { FromZip = "9121", ToZip = "93831", DistanceInMiles = 0 };
            var DistanceCalculated = new CalculatedDistance { FromZip = "9121", ToZip = "93831", DistanceInMiles = 22.341};

            #endregion

            #region Setup       
            MockService.Setup(s => s.CalculateDistance(calculateDistance))
                .ReturnsAsync(DistanceCalculated)
                .Verifiable();
            #endregion

            #region Call                        
            var result = Controller.CalculateDistance(calculateDistance) as OkObjectResult;
            #endregion

            #region Verify
            MockService.Verify(s => s.CalculateDistance(calculateDistance), Times.Once);
            #endregion

            #region Assert     
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<CalculatedDistance>(result.Value);
            #endregion
        }
    }
}
