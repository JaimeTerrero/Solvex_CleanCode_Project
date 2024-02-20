using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Users.DTOs;

namespace VirtPlatform.Application.Users.Interfaces
{
    public interface IUserService : IService<User, UserDto>
    {
        Task<User> Register(SignUp signUp);
        Task<User> Authenticate(LogIn logIn);
    }
}
