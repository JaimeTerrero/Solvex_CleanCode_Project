using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Domain.Interfaces.Repositories.Assignments;
using VirtPlatform.Infrastructure.Context;

namespace VirtPlatform.Infrastructure.Repositories.Assignments
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AssignmentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Assignment> AddAsync(Assignment assignment)
        {
            await _applicationDbContext.Assignments.AddAsync(assignment);
            await _applicationDbContext.SaveChangesAsync();
            return assignment;
        }

        public async Task DeleteAsync(int id)
        {
            var assignment = await _applicationDbContext.Assignments.FindAsync(id);
            _applicationDbContext.Set<Assignment>().Remove(assignment);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<Assignment>> GetAllAsync()
        {
            return await _applicationDbContext.Set<Assignment>().ToListAsync();
        }

        public async Task<Assignment> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Set<Assignment>().FindAsync(id);
        }

        public async Task UpdateAsync(Assignment assignment)
        {
            _applicationDbContext.Entry(assignment).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
