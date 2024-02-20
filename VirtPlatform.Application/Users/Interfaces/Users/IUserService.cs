using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Users.DTOs.Users;

namespace VirtPlatform.Application.Users.Interfaces.Users
{
    public interface IUserService : IService<User, UserDto>
    {
    }
}
