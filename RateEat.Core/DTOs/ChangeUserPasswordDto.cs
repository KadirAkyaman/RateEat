using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateEat.Core.DTOs
{
    public class ChangeUserPasswordDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}