using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.DTOs
{
    public class UpdateUserProfileDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}