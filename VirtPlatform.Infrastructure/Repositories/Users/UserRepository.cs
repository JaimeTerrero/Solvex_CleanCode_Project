using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Domain.Interfaces.Repositories.Users;
using VirtPlatform.Infrastructure.Context;

namespace VirtPlatform.Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<User> AddAsync(User user)
        {
            await _applicationDbContext.Users.AddAsync(user);
            await _applicationDbContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _applicationDbContext.Users.FindAsync(id);
            _applicationDbContext.Set<User>().Remove(user);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _applicationDbContext.Set<User>().ToListAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _applicationDbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Set<User>().FindAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            _applicationDbContext.Entry(user).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
