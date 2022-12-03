using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniqueColumn.Models;

namespace UniqueColumn.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Student> Student { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Student>().HasIndex(u => u.PhoneNo).IsUnique();
            builder.Entity<Student>().HasIndex(u => u.Email).IsUnique();
        }
    }
}