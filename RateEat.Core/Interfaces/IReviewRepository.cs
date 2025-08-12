using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateEat.Core.Entities;

namespace RateEat.Core.Interfaces
{
    public interface IReviewRepository
    {
        Task AddAsync(Review review);
        Task<bool> HasUserReviewedRestaurantAsync(int userId, int restaurantId);
        Task<Review?> GetByIdAsync(int id);
        Task DeleteAsync(Review review);
    }
}