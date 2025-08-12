using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.DTOs
{
    public class ReservationConfirmationDto // For a successful reservation response.
    {
        public int ReservationId { get; set; }
        public string RestaurantName { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }
        public string Status { get; set; }
    }
}