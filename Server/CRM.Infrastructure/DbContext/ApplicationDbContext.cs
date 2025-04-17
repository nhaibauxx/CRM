using Microsoft.EntityFrameworkCore;
using CRM.Domain.Entities;

namespace CRM.Infrastructure.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add your entity configurations here
        }

        // Add your DbSet properties here
    }
} 