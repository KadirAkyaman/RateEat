using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.DTOs
{
    public class UpdateRestaurantDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CuisineType { get; set; }
    }
}