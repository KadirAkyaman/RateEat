using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.Entities
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}