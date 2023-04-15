using LendingAPI.Business.Models;

namespace LendingAPI
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<DistancesCollection, DistanceDto>().ReverseMap();
        }
    }
}
