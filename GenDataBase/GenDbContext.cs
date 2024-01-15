using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Entities.ApplicationUser;
using System.Reflection.Emit;

namespace GenDataBase
{
    public class GenDbContext:IdentityDbContext
    {
        public virtual DbSet<PrimaryUser> Users { get; set; }
        public GenDbContext(DbContextOptions<GenDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PrimaryUser>().ToTable("Primary Users");
            builder.Entity<PrimaryUser>().HasData(new PrimaryUser()
            {
                Id = Guid.Parse("F65DEE5C-A3BB-4B8E-A12C-78B6E3E7E517"),
               First_Name="Ben",
               Last_Name="Tennyson",
               Email="ben10@gmail.com",
               roles=Entities.Enums.Roles.PrimaryUser,
               PasswordHash="Paashw",
               
            });
        }

    }
}