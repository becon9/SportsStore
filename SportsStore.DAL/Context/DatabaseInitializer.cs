using Microsoft.EntityFrameworkCore;
using SportsStore.DAL.Entities;

namespace SportsStore.DAL.Context
{
    public static class DatabaseInitializer
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Kayak",
                    Description = "A boat for one person",
                    Category = "Watersports",
                    Price = 275
                },
                new Product
                {
                    Id = 2,
                    Name = "Lifejacket",
                    Description = "Protective and fashionable",
                    Category = "Watersports",
                    Price = 48.95m
                },
                new Product
                {
                    Id = 3,
                    Name = "Soccer Ball",
                    Description = "FIFA-approved size and weight",
                    Category = "Soccer",
                    Price = 19.50m
                },
                new Product
                {
                    Id = 4,
                    Name = "Corner Flags",
                    Description = "Give your playing field a professional touch",
                    Category = "Soccer",
                    Price = 39.95m
                },
                new Product
                {
                    Id = 5,
                    Name = "Stadium",
                    Description = "Flat-packed 35,000-seat stadium",
                    Category = "Soccer",
                    Price = 79500
                },
                new Product
                {
                    Id = 6,
                    Name = "Thinking Cap",
                    Description = "Improve brain efficiency by 75%",
                    Category = "Chess",
                    Price = 16
                },
                new Product
                {
                    Id = 7,
                    Name = "Unsteady Chair",
                    Description = "Secretly give your opponent a disadvantage",
                    Category = "Chess",
                    Price = 29.95m
                },
                new Product
                {
                    Id = 8,
                    Name = "Human Chess Board",
                    Description = "A fun game for family",
                    Category = "Chess",
                    Price = 75
                },
                new Product
                {
                    Id = 9,
                    Name = "Bling-Bling King",
                    Description = "Gold-plated, diamong-studded King",
                    Category = "Chess",
                    Price = 1200
                }
            );
        }
    }
}