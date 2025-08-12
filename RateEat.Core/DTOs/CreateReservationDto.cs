using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.DTOs
{
    public class CreateReservationDto
    {
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }     
    }
}