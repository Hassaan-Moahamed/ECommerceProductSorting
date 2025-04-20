using Microsoft.EntityFrameworkCore;
using ECommerceProductSorting.Models;

namespace ECommerceProductSorting.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "iPhone 14", Price = 999, Rating = 4.5, Category = "Phones", Brand = "Apple" },
                new Product { Id = 2, Name = "Galaxy S23", Price = 829, Rating = 4.3, Category = "Phones", Brand = "Samsung" },
                new Product { Id = 3, Name = "MacBook Air1", Price = 1299, Rating = 4.8, Category = "Laptops", Brand = "Apple" },
                new Product { Id = 4, Name = "Dell XPSf", Price = 1099, Rating = 4.6, Category = "Laptops", Brand = "Dell" },
                 new Product { Id = 5, Name = "iPhone 15", Price = 989, Rating = 3.5, Category = "Phones", Brand = "Apple" },
                new Product { Id = 6, Name = "Galaxy S24", Price = 859, Rating = 2.3, Category = "Phones", Brand = "Samsung" },
                new Product { Id = 7, Name = "MacBook Air2", Price = 1599, Rating = 1.8, Category = "Laptops", Brand = "Apple" },
                new Product { Id = 8, Name = "Dell XPSd", Price = 1099, Rating = 4.3, Category = "Laptops", Brand = "Dell" },
                new Product { Id = 9, Name = "iPhone 16", Price = 979, Rating = 3.6, Category = "Phones", Brand = "Apple" },
                new Product { Id = 10, Name = "Galaxy S25", Price = 809, Rating = 4.1, Category = "Phones", Brand = "Samsung" },
                new Product { Id = 11, Name = "MacBook Air3", Price = 1499, Rating = 2.1, Category = "Laptops", Brand = "Apple" },
                new Product { Id = 12, Name = "Dell XPSw", Price = 1099, Rating = 4.9, Category = "Laptops", Brand = "Dell" }, 
                new Product { Id = 13, Name = "iPhone 17", Price = 969, Rating = 4.5, Category = "Phones", Brand = "Apple" },
                new Product { Id = 14, Name = "Galaxy S28", Price = 819, Rating = 4.3, Category = "Phones", Brand = "Samsung" },
                new Product { Id =15, Name = "MacBook Air4", Price = 1399, Rating = 3.4, Category = "Laptops", Brand = "Apple" },
                new Product { Id = 16, Name = "Dell XPSe", Price = 1099, Rating = 1.1, Category = "Laptops", Brand = "Dell" }
            );
        }
    }
}
