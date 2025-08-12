using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.Entities
{
    public class Restaurant : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = false;
        public string Description { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string CuisineType { get; set; }
        public double OverallScore { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public ICollection<RestaurantAvailability> Availabilities { get; set; }
    }
}