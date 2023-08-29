using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace E_commerce.Data
{
    public class E_commerceDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Categories { get; set; }
        public E_commerceDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
             new Category { Id = 1, Name = "Electronics" },
             new Category { Id = 2, Name = "Computers & Tablets" },
             new Category { Id = 3, Name = "Makeup" }
             );

            modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "LG Microwave", Price = 155.00, Description = "Great , Large ,A++ electricity consuming", CategoryId = 1 },
            new Product { Id = 2, Name = "Dish Washer", Price = 450.00, Description = "cleaning dishes in a foodservice environment to ensure that there is always plenty of clean tableware at hand", CategoryId = 1 },
            new Product { Id = 3, Name = "SAMSUNG TV ", Price = 500.00, Description = "75\" Neo QLED 4K HDR Screen", CategoryId = 1 },
            new Product { Id = 4, Name = "SAMSUNG Galaxy Tab A8", Price = 170.00, Description = "SAMSUNG Galaxy Tab A8 10.5” 32GB Android Tablet, LCD Screen, Kids Content, Smart Switch, Long Lasting Battery, US Version, 2022, Dark Gray", CategoryId = 2 },
            new Product { Id = 5, Name = "Maybelline Mascara", Price = 24.00, Description = " Lash Sensational Sky High Washable ,Volumizing, Lengthening, Defining,", CategoryId = 3 },
            new Product { Id = 7, Name = "acer 2023 Newest Chromebook 15.6\"", Price = 205.00, Description = "acer 2023 Newest Chromebook 15.6\" FHD 1080p IPS Touchscreen Light Computer Laptop, Due-core Intel Celeron N4020, 4GB RAM, 64GB", CategoryId = 2 },
            new Product { Id = 8, Name = "NYX PROFESSIONAL MAKEUP Epic Ink Liner", Price =9.00, Description = ", Waterproof Liquid Eyeliner - Black, Vegan Formula", CategoryId = 3 }
            );
        }
    }
}

