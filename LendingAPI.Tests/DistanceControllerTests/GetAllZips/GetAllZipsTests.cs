using LendingAPI.Business.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingAPI.Tests.DistanceControllerTests.GetAllZips
{
    public class GetAllZipsTests : DistanceControllerTests
    {
        [Fact]
        public async Task Will_Return_All_Zip_Information()
        {
            #region Variables    
            var expectedData = new List<DistanceDto>
            {
                new DistanceDto
                { City = "Anaheim", Id = new ObjectId("643ac1892fd11d97d4829d19"), LAT = 33.844983, LNG = -117.952151, ZIP = "9121" },
                new DistanceDto
                { City = "Los Angeles", Id = new ObjectId("643ac1892fd11d97d4829d19"), LAT = 33.844983, LNG = -117.952151, ZIP = "93831" },
                new DistanceDto
                { City = "New York", Id = new ObjectId("643ac1892fd11d97d4829d19"), LAT = 33.844983, LNG = -117.952151, ZIP = "87232" },

            };

            #endregion

            #region Setup       
            MockService.Setup(s => s.GetAllZipsInfoAsync())
                .ReturnsAsync(expectedData)
                .Verifiable();
            #endregion

            #region Call                        
            var result = await Controller.GetAllZips() as ActionResult;
            #endregion

            #region Verify
            MockService.Verify(s => s.GetAllZipsInfoAsync(), Times.Once);
            #endregion

            #region Assert     
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
            #endregion
        }

        [Fact]
        public async Task Will_Return_Not_Found_All_Zip_Information()
        {
            #region Variables    
            var expectedData = new List<DistanceDto>
            {
            };

            #endregion

            #region Setup       
            MockService.Setup(s => s.GetAllZipsInfoAsync())
                .ReturnsAsync(expectedData)
                .Verifiable();
            #endregion

            #region Call                        
            var result = await Controller.GetAllZips() as OkObjectResult;
            #endregion

            #region Verify
            MockService.Verify(s => s.GetAllZipsInfoAsync(), Times.Once);
            #endregion

            #region Assert     
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<DistanceDto>>(result.Value);
            #endregion
        }
    }
}
