using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateEat.Core.Entities;

namespace RateEat.Core.Interfaces
{
    public interface IReservationRepository
    {
        Task AddAsync(Reservation reservation);
        Task<RestaurantAvailability?> GetAvailabilityForUpdateAsync(int restaurantId, DateOnly date, TimeOnly timeSlot);
        Task UpdateAvailabilityAsync(RestaurantAvailability availability);
        Task AddAvailabilityAsync(RestaurantAvailability availability);
        Task<bool> HasActiveReservationForTimeSlotAsync(int userId, int restaurantId, DateTime dateTime);
        Task<Reservation?> GetByIdAsync(int id);
        Task UpdateAsync(Reservation reservation);
    }
}