using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.Entities
{
    public class Review : BaseEntity
    {
        public int ServiceScore { get; set; }
        public int FlavorScore { get; set; }
        public int AmbianceScore { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}