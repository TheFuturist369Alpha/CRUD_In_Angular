using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Entities.ApplicationUser;

namespace GenDataBase
{
    public class GenDbContext:IdentityDbContext
    {
        public DbSet<PrimaryUser> Users { get; set; }
        public GenDbContext(DbContextOptions<GenDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PrimaryUser>().ToTable("Primary Users");
        }

    }
}