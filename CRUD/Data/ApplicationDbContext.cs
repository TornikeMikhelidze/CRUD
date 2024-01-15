using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { Id = 1, FirstName = "Emily", LastName= "Johnson", DisplayOrder = 1 },
                new User { Id = 2, FirstName = "Daniel", LastName = "Rodriguez", DisplayOrder = 2 },
                new User { Id = 3, FirstName = "Olivia", LastName = "Mitchell", DisplayOrder = 3 },
                new User { Id = 4, FirstName = "Sophia", LastName = "Taylor", DisplayOrder = 5 },
                new User { Id = 5, FirstName = "Ethan", LastName = "Martinez", DisplayOrder = 4 }
            );
        }
    }
}
