using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.DTOs
{
    public class RestaurantSummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CuisineType { get; set; }
        public double OverallScore { get; set; }
    }
}