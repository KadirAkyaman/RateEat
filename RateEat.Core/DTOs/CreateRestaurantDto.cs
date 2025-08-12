using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.DTOs
{
    public class CreateRestaurantDto
    {
        string Name { get; set; }
        string Description { get; set; }
        string Address { get; set; }
        string PhoneNumber { get; set; }
        string CuisineType { get; set; }
    }
}