using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.DTOs
{
    public class ReviewDto
    {
        public string AuthorName { get; set; }
        public string Comment { get; set; }
        public int ServiceScore { get; set; }
        public int FlavorScore { get; set; }
        public int AmbianceScore { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}