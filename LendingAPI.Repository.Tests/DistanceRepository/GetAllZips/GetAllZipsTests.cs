using LendingAPI.Business.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingAPI.Repository.Tests.DistanceRepositorys.GetAllZips
{
    public class GetAllZipsTests : DistanceRepositoryTests
    {
        [Fact]
        public async Task Will_Found_Zip_information()
        {
            #region Variables
            var expectedData = new List<DistancesCollection> {
                new DistancesCollection{
                    ZIP = "8912",
                    LAT = 13.12,
                    LNG = -11.232,
                    City = "Prueba"
                }
            };
            #endregion

            #region Setup            
            mockCursor.Setup(_ => _.Current).Returns(expectedData);
            mockCursor.Setup(_ => _.MoveNextAsync(default)).ReturnsAsync(true);
            mockCursor.Setup(_ => _.MoveNextAsync(default)).ReturnsAsync(false);
            #endregion

            #region Call
            var result = await DistanceRepository.GetAllZips();
            #endregion

            #region Verify

            #endregion

            #region Assert
            Assert.Equal(880, result.Count());
            #endregion             
        }
    }
}
