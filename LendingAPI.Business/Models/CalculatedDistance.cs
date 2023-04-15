using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingAPI.Business.Models
{
    public class CalculatedDistance
    {
        public string FromZip { get; set; }
        public string ToZip { get; set; }
        public double DistanceInMiles { get; set; }
    }
}
