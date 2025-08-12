using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateEat.Core.DTOs;

namespace RateEat.Core.Interfaces
{
    public interface IRestaurantAnalyticsRepository
    {
    Task<IEnumerable<BestValueRestaurantDto>> GetBestValueRestaurantsAsync(int count);
    
    Task<IEnumerable<TopRatedRestaurantDto>> GetTopRatedByCuisineAsync(string cuisine, string scoreType, int count);
    
    Task<IEnumerable<TopRatedRestaurantDto>> GetMostReviewedRestaurantsAsync(int count);
    }
}