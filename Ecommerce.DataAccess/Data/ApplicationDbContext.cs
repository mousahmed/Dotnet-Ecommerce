using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
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

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "The Lord of the Rings",
                    Description = "The Lord of the Rings is an epic high-fantasy novel written by English author and scholar J. R. R. Tolkien.",
                    ISBN = "978-0-395-19395-7",
                    Author = "J. R. R. Tolkien",
                    ListPrice = 19.99,
                    Price = 14.99,
                    Price50 = 13.99,
                    Price100 = 12.99
                },
                new Product
                {
                    Id = 2,
                    Title = "Harry Potter and the Philosopher's Stone",
                    Description = "Harry Potter and the Philosopher's Stone is a fantasy novel written by British author J. K. Rowling.",
                    ISBN = "978-0-7475-3269-6",
                    Author = "J. K. Rowling",
                    ListPrice = 14.99,
                    Price = 9.99,
                    Price50 = 8.99,
                    Price100 = 7.99
                },
                new Product
                {
                    Id = 3,
                    Title = "The Da Vinci Code",
                    Description = "The Da Vinci Code is a 2003 mystery thriller novel by Dan Brown.",
                    ISBN = "978-0-385-50420-5",
                    Author = "Dan Brown",
                    ListPrice = 12.99,
                    Price = 7.99,
                    Price50 = 6.99,
                    Price100 = 5.99
                },
                  new Product
                  {
                      Id = 4,
                      Title = "The Shining",
                      Description = "The Shining is a horror novel by American author Stephen King.",
                      ISBN = "978-0-385-12167-5",
                      Author = "Stephen King",
                      ListPrice = 9.99,
                      Price = 4.99,
                      Price50 = 3.99,
                      Price100 = 2.99
                  },
                  new Product
                  {
                      Id = 5,
                      Title = "The Notebook",
                      Description = "The Notebook is a 1996 romantic novel by American novelist Nicholas Sparks.",
                      ISBN = "978-0-446-52080-5",
                      Author = "Nicholas Sparks",
                      ListPrice = 7.99,
                      Price = 2.99,
                      Price50 = 1.99,
                      Price100 = 0.99
                  },
                  new Product
                  {
                      Id = 6,
                      Title = "The Hunger Games",
                      Description = "The Hunger Games is a 2008 dystopian novel by the American writer Suzanne Collins.",
                      ISBN = "978-0-439-02348-1",
                      Author = "Suzanne Collins",
                      ListPrice = 11.99,
                      Price = 6.99,
                      Price50 = 5.99,
                      Price100 = 4.99
                  },
                  new Product
                  {
                      Id = 7,
                      Title = "Game of Thrones",
                      Description = "Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by the American author George R. R. Martin.",
                      ISBN = "978-0-553-57340-4",
                      Author = "George R. R. Martin",
                      ListPrice = 15.99,
                      Price = 10.99,
                      Price50 = 9.99,
                      Price100 = 8.99
                  }
                );
        }
    }
}
