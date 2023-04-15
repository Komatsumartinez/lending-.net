using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingAPI.Business.Models
{
    public class DistanceDto
    {
        public ObjectId Id { get; set; }
        public string ZIP { get; set; }
        public double LAT { get; set; }
        public double LNG { get; set; }
        public string City { get; set; }
    }
}
