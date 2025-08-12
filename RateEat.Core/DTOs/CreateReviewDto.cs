using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.DTOs
{
    public class CreateReviewDto
    {
        public string Comment { get; set; }
        public int ServiceScore { get; set; }
        public int FlavorScore { get; set; }
        public int AmbianceScore { get; set; }
    }
}