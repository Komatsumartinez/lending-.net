using AutoMapper;
using LendingAPI.Business.Contracts;
using LendingAPI.Business.Models;
using LendingAPI.Repository.Contracts;
using Moq;

namespace LendingAPI.Business.Tests.DistanceServiceTests
{
    public class DistanceServiceTests
    {
        protected DistanceService Service { get; set; }
        protected Mock<IDistanceRepository> MockDistanceRepository { get; set; }
        protected IMapper MockMapper { get; set; }
        public DistanceServiceTests()
        {
            MockDistanceRepository = new Mock<IDistanceRepository>();
            MockMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DistancesCollection, DistanceDto>().ReverseMap();
            }).CreateMapper();
            Service = new DistanceService(MockDistanceRepository.Object, MockMapper);
        }
    }
}