using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateEat.Core.DTOs;

namespace RateEat.Core.Interfaces
{
    public interface IReviewService
    {
        Task CreateReviewAsync(int userId, int restaurantId, CreateReviewDto reviewDto);
        Task DeleteReviewAsync(int reviewId, int userId);
    }
}