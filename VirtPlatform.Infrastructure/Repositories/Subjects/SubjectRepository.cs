using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Domain.Interfaces.Repositories.Subjects;
using VirtPlatform.Infrastructure.Context;

namespace VirtPlatform.Infrastructure.Repositories.Subjects
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SubjectRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Subject> AddAsync(Subject subject)
        {
            await _applicationDbContext.Subjects.AddAsync(subject);
            await _applicationDbContext.SaveChangesAsync();
            return subject;
        }

        public async Task DeleteAsync(int id)
        {
            var subject = await _applicationDbContext.Subjects.FindAsync(id);
            _applicationDbContext.Set<Subject>().Remove(subject);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<Subject>> GetAllAsync()
        {
            return await _applicationDbContext.Set<Subject>().ToListAsync();
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Set<Subject>().FindAsync(id);
        }

        public async Task UpdateAsync(Subject subject)
        {
            _applicationDbContext.Entry(subject).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
