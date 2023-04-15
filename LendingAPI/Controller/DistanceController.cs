using LendingAPI.Business.Contracts;
using LendingAPI.Business.Models;
using LendingAPI.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LendingAPI.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class DistanceController : ControllerBase
    {
        private readonly IDistanceService _distanceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistanceController" /> class.
        /// </summary>
        /// <param name="distanceService">The integration service.</param>        
        /// <exception cref="ArgumentNullException">service</exception>
        public DistanceController(IDistanceService distanceService)
        {
            _distanceService = distanceService ?? throw new ArgumentNullException(nameof(distanceService));
        }

        /// <summary>
        /// CalcuLATe Distance in miles between two zip codes.
        /// </summary>
        /// <param name="distance">The distance model</param>
        /// <returns>
        ///   <see cref="DistancesCollection" />.
        /// </returns>
        /// <response code="200">Returns the distance calcuLATed.</response>
        /// <response code="400">There was an error with the zips.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPost]
        public ActionResult CalculateDistance(CalculatedDistance distance)
        {
            if (distance.FromZip == "" || distance.ToZip == "")
            {
                return BadRequest("Invalid zip code(s)");
            }
            var result = _distanceService.CalculateDistance(distance);

            return Ok(distance);
        }

        /// <summary>
        /// Get all zips info on mongodb
        /// </summary>
        /// <param name="distance">The distance model</param>
        /// <returns>
        ///   <see cref="DistancesCollection" />.
        /// </returns>
        /// <response code="200">Returns the distance calcuLATed.</response>
        /// <response code="400">There was an error with the zips.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpGet]
        public async Task<ActionResult> GetAllZips()
        {
            return Ok(await _distanceService.GetAllZipsInfoAsync());
        }

    }
}

