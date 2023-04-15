using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingAPI.Business.Models
{
    public class DistancesCollection
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string ZIP { get; set; }
        public double LAT { get; set; }
        public double LNG { get; set; }
        public string City { get; set; }       
    }
}
