using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Infrastructure.Settings
{
    public class DatabaseSettings
    {
        public const string SectionName = "ConnectionStrings";
        public required string DefaultConnection { get; set; } 
    }
}