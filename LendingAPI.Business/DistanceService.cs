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
            distanceFrom.LNG = toRadians(distanceFrom.LNG);
            distanceTo.LNG = toRadians(distanceTo.LNG);
            distanceFrom.LAT = toRadians(distanceFrom.LAT);
            distanceTo.LAT = toRadians(distanceTo.LAT);

            double dlon = distanceTo.LNG - distanceFrom.LNG;
            double dLAT = distanceTo.LAT - distanceFrom.LAT;
            double a = Math.Pow(Math.Sin(dLAT / 2), 2) +
                       Math.Cos(distanceFrom.LAT) * Math.Cos(distanceTo.LAT) *
                       Math.Pow(Math.Sin(dlon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));
            double r = 6371;
            return (c * r);
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