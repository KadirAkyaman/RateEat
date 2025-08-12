using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.DTOs
{
    public class RestaurantDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string CuisineType { get; set; }
        public double OverallScore { get; set; }
        public List<ReviewDto> Reviews { get; set; }
        public List<MenuDto> Menus { get; set; }     
    }
}