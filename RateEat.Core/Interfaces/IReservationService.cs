using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateEat.Core.DTOs;

namespace RateEat.Core.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationConfirmationDto> MakeReservationAsync(int userId, int restaurantId, CreateReservationDto reservationDto );
        Task CancelReservationAsync(int reservationId, int userId);
    }
}