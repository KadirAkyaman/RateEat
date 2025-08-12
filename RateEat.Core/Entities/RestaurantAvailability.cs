using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.Entities
{
    public class RestaurantAvailability : BaseEntity
    {
        public DateOnly Date { get; set; }//The date on which the quota is valid.
        public TimeOnly TimeSlot { get; set; }//Time period during which the quota is valid
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}