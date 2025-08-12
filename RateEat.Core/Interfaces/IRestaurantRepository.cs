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
        Task AddRestaurantAsync(Restaurant restaurant);
        Task DeleteRestaurantAsync(int id);
        Task UpdateRestaurantAsync(Restaurant restaurant);
        Task<IEnumerable<Restaurant>> GetByCuisineTypeAsync(string cuisine);
        Task<bool> RestaurantExistsAsync(int id);
    }
}