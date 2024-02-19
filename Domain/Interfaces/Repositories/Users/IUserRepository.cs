using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtPlatform.Domain.Interfaces.Repositories.Users
{
    public interface IUserRepository : RepositoryT<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
