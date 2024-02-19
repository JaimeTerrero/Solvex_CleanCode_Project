using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtPlatform.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
            .HasOne(a => a.User)
            .WithMany(u => u.Assignments)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Assignment>()
            .HasOne(a => a.Subject)
            .WithMany(s => s.Assignments)
            .HasForeignKey(a => a.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
