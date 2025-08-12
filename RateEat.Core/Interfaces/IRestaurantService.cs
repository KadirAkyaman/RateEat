using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateEat.Core.DTOs;

namespace RateEat.Core.Interfaces
{
    public interface IRestaurantService
    {
        Task<RestaurantDetailDto> GetRestaurantByIdAsync(int restaurantId);
        Task<IEnumerable<RestaurantSummaryDto>> GetAllRestaurantsAsync();
        Task<int> CreateRestaurantAsync(CreateRestaurantDto restaurantDto);
        Task UpdateRestaurantAsync(int restaurantId, UpdateRestaurantDto restaurantDto);
        Task DeleteRestaurantAsync(int restaurantId);

        //reporting methods
        Task<IEnumerable<BestValueRestaurantDto>> GetBestValueRestaurantsReportAsync(int count);
        Task<IEnumerable<TopRatedRestaurantDto>> GetTopRatedByCuisineReportAsync(string cuisine, string scoreType, int count);
        Task<IEnumerable<TopRatedRestaurantDto>> GetMostReviewedRestaurantsReportAsync(int count);
    }
}