using LendingAPI.Business.Contracts;
using LendingAPI.Controller;
using Moq;

namespace LendingAPI.Tests.DistanceControllerTests
{
    public class DistanceControllerTests
    {
        public Mock<IDistanceService> MockService { get; set; }        

        public DistanceController Controller { get; set; }
        public DistanceControllerTests()
        {
            MockService = new Mock<IDistanceService>();

            Controller = new DistanceController(MockService.Object);
        }
    }
}