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
        public DbSet<Forum> Forums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Assignment relationship

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

            #endregion

            modelBuilder.Entity<Forum>()
            .HasOne(f => f.User)
            .WithMany(u => u.Forums)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Restrict); // Esto especifica ON DELETE NO ACTION

            modelBuilder.Entity<Forum>()
            .HasOne(f => f.Subject)
            .WithMany(s => s.Forums)
            .HasForeignKey(f => f.SubjectId)
            .OnDelete(DeleteBehavior.Restrict); // Esto especifica ON DELETE NO ACTION

        }
    }
}
