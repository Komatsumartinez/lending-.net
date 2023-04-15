using LendingAPI.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingAPI.Repository.Contracts
{
    public interface IDistanceRepository
    {
        Task<DistancesCollection> GetDistanceByZips(string zipCode);
        Task<List<DistancesCollection>> GetAllZips();
    }
}
