using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder=1  },
                new Category { Id = 2, Name = "Adventure", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Comedy", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Drama", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Fantasy", DisplayOrder = 5 },
                new Category { Id = 6, Name = "Horror", DisplayOrder = 6 },
                new Category { Id = 7, Name = "Mystery", DisplayOrder = 7 },
                new Category { Id = 8, Name = "Romance", DisplayOrder = 8 },
                new Category { Id = 9, Name = "Sci-Fi", DisplayOrder = 9 },
                new Category { Id = 10, Name = "Thriller", DisplayOrder = 10 }
            );
        }
    }
}
