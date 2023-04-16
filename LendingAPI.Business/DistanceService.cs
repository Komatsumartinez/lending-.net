using AutoMapper;
using LendingAPI.Business.Contracts;
using LendingAPI.Business.Models;
using LendingAPI.Repository.Contracts;
using MongoDB.Bson;
using System.Reflection.Emit;

namespace LendingAPI.Business
{
    public class DistanceService : IDistanceService
    {
        private readonly IDistanceRepository _distanceRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistanceService"/> class.
        /// </summary>
        /// <param name="distanceRepository">The Distance Repository.</param>
        /// <param name="mapper">The Distance Repository.</param>
        public DistanceService(IDistanceRepository distanceRepository, IMapper mapper)
        {
            _distanceRepository = distanceRepository ?? throw new ArgumentNullException(nameof(distanceRepository)); ;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Find the distance in miles between two zip codes.
        /// </summary>
        /// <param name="distance">The distance model <see cref="DistancesCollection"/>.</param>
        /// <returns>The <see cref="DistancesCollection"/> calcuLATed.</returns>
        public async Task<CalculatedDistance> CalculateDistance(CalculatedDistance distance)
        {
            var fromInfo = await GetDistanceByZipAsync(distance.FromZip);
            var toInfo = await GetDistanceByZipAsync(distance.ToZip);
            distance.DistanceInMiles = DistanceInMiles(fromInfo, toInfo);
            return distance;
        }


        /// <summary>
        /// Get Zip info on mongodb
        /// </summary>
        /// <param name="zip">The zip code.</param>              
        public async Task<DistanceDto> GetDistanceByZipAsync(string zip)
        {            
            return _mapper.Map<DistanceDto>(await _distanceRepository.GetDistanceByZips(zip));
        }


        /// <summary>
        /// Get all Zips info on mongodb
        /// </summary>
        /// <returns>The list of <see cref="DistanceDto"/> foundeds.</returns>            
        public async Task<List<DistanceDto>> GetAllZipsInfoAsync()
        {            
            return _mapper.Map<List<DistanceDto>>(await _distanceRepository.GetAllZips()); ;
        }

        #region Helper Methods
        private double DistanceInMiles(DistanceDto distanceFrom, DistanceDto distanceTo)
        {
            const double r = 3958.8; 

            var dLat = toRadians(distanceTo.LAT - distanceFrom.LAT);
            var dLon = toRadians(distanceTo.LNG - distanceFrom.LNG);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(toRadians(distanceFrom.LAT)) * Math.Cos(toRadians(distanceTo.LAT)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var distance = r * c;

            return distance;

        }

        private double toRadians(
           double angleIn10thofaDegree)
        {
            return (angleIn10thofaDegree *
                           Math.PI) / 180;
        }
        #endregion
    }
}