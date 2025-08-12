using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateEat.Core.Entities;

namespace RateEat.Core.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<Restaurant> GetRestaurantByIdAsync(int id);
        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
        Task<bool> AddRestaurantAsync(Restaurant restaurant);
        Task<bool> DeleteRestaurantAsync(int id);
        Task<bool> UpdateRestaurantAsync(Restaurant restaurant);
        Task<IEnumerable<Restaurant>> GetByCuisineTypeAsync(string cuisine);
        Task<IEnumerable<Restaurant>> GetTopRatedAsync(int count);
        Task<double> GetAverageScoreAsync(int restaurantId);
    }
}