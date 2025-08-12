using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateEat.Core.Entities;

namespace RateEat.Core.DTOs
{
    public class MenuDto
    {
        public string Name { get; set; }
        public List<MenuItemDto> MenuItems { get; set; }
    }
}