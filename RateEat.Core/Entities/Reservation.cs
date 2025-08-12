using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.Entities
{
    public class Reservation : BaseEntity
    {
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}