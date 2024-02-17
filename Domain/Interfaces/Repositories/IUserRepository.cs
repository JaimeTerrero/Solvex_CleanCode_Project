using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtPlatform.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task GetByEmailAsync(string email);
    }
}
