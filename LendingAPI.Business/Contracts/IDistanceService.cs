using LendingAPI.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingAPI.Business.Contracts
{
    public interface IDistanceService
    {
        Task<CalculatedDistance> CalculateDistance(CalculatedDistance distance);
        Task<DistanceDto> GetDistanceByZipAsync(string zip);
        Task<List<DistanceDto>> GetAllZipsInfoAsync();
    }
}
