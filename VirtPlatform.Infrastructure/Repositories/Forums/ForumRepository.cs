using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VirtPlatform.Domain.Interfaces.Repositories.Forums;
using VirtPlatform.Infrastructure.Context;

namespace VirtPlatform.Infrastructure.Repositories.Forums
{
    public class ForumRepository : IForumRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ForumRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Forum> AddAsync(Forum forum)
        {
            await _applicationDbContext.Forums.AddAsync(forum);
            await _applicationDbContext.SaveChangesAsync();
            return forum;
        }

        public async Task DeleteAsync(int id)
        {
            var forum = await _applicationDbContext.Forums.FindAsync(id);
            _applicationDbContext.Set<Forum>().Remove(forum);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<Forum>> GetAllAsync()
        {
            return await _applicationDbContext.Set<Forum>().ToListAsync();
        }

        public async Task<Forum> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Set<Forum>().FindAsync(id);
        }

        public async Task UpdateAsync(Forum forum)
        {
            _applicationDbContext.Entry(forum).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
