using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateEat.Core.DTOs;

namespace RateEat.Core.Interfaces
{
    public interface IUserService
    {
        Task RegisterUserAsync(UserRegisterDto userRegisterDto);
        Task UpdateProfileAsync(int userId, UpdateUserProfileDto updateUserProfileDto);
        Task DeactiveUserAsync(int userId);
    }
}