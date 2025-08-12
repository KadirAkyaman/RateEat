using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.DTOs
{
    public class BestValueRestaurantDto
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public double AverageMenuPrice { get; set; }
        public double OverallScore { get; set; }
        public double ValueScore { get; set; }
    }
}