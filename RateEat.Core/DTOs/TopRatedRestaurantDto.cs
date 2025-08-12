using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.DTOs
{
    public class TopRatedRestaurantDto
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string CuisineType { get; set; }
        public int SpecificScore { get; set; }
    }
}