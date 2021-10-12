using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iStore.Models
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public DbSet<Product> products { get; set; }
        public DbSet<Vendor> vendors { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Wishlist> wishlists { get; set; }
        public DbSet<VendorStock> vendorStocks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VendorStock>()
                .HasNoKey();
            

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "iPhone13ProMax",
                    Price = 139900,
                    Description = "It has a 8GB Ram/512GB ROM and a processor of A15 bionic chip with a display of 6.7 inches",
                    Rating = 9.8M
                },
                new Product
                {
                    Id = 2,
                    Name = "iPhone13Pro",
                    Price = 119900,
                    Description = "It has a 8GB Ram/256GB ROM and a processor of A15 bionic chip with a display of 6.1 inches",
                    Rating = 9.6M
                },
                new Product
                {
                    Id = 3,
                    Name = "iPhone13",
                    Price = 69900,
                    Description = "It has a 8GB Ram/256GB ROM and a processor of A15 bionic chip with a display of 6.1 inches",
                    Rating = 9.4M
                },
                new Product
                {
                    Id = 4,
                    Name = "iPhone13Mini",
                    Price = 65900,
                    Description = "It has a 4GB Ram/128GB ROM and a processor of A13 bionic chip with a display of 5.4 inches",
                    Rating = 9.2M
                },
                new Product
                {
                    Id = 5,
                    Name = "iPhone12ProMax",
                    Price = 100900,
                    Description = "It has a 8GB Ram/512GB ROM and a processor of A14 bionic chip with a display of 6.7 inches",
                    Rating = 9.5M
                },
                new Product
                {
                    Id = 6,
                    Name = "iPhone12Pro",
                    Price = 90900,
                    Description = "It has a 8GB Ram/256GB ROM and a processor of A14 bionic chip with a display of 6.1 inches",

                    Rating = 9.3M
                },
                new Product
                {
                    Id = 7,
                    Name = "iPhone12",
                    Price = 59900,
                    Description = "It has a 6GB Ram/128GB ROM and a processor of A14 bionic chip with a display of 5.4 inches",
                    Rating = 9.1M
                },
                new Product
                {
                    Id = 8,
                    Name = "iPhone12Mini",
                    Price = 56900,
                    Description = "It has a 6GB Ram/64GB ROM and a processor of A14 bionic chip with a display of 4.7 inches",
                    Rating = 8.5M
                },
                new Product
                {
                    Id = 9,
                    Name = "iPhoneSE",
                    Price = 39900,
                    Description = "It has a 4GB Ram/64GB ROM and a processor of A14 bionic chip with a display of 6.7 inches",
                    Rating = 8.3M
                },
                new Product
                {
                    Id = 10,
                    Name = "iPhone11ProMax",
                    Price = 65900,
                    Description = "It has a 8GB Ram/512GB ROM and a processor of A13 bionic chip with a display of 6.5 inches",
                    Rating = 9.1M
                },
                new Product
                {
                    Id = 11,
                    Name = "iPhone11Pro",
                    Price = 55900,
                    Description = "It has a 8GB Ram/256GB ROM and a processor of A12 bionic chip with a display of 5.8 inches",
                    Rating = 8.9M
                },
                new Product
                {
                    Id = 12,
                    Name = "iPhone11",
                    Price = 49900,
                    Description = "It has a 6GB Ram/128GB ROM and a processor of A13 bionic chip with a display of 6.1 inches",
                    Rating = 8.5M
                },
                new Product
                {
                    Id = 13,
                    Name = "iPhoneX",
                    Price = 52900,
                    Description = "It has a 6GB Ram/256GB ROM and a processor of A13 bionic chip with a display of 5.8 inches",
                    Rating = 8.5M
                },
                new Product
                {
                    Id = 14,
                    Name = "iPhoneXSMAX",
                    Price = 55900,
                    Description = "It has a 8GB Ram/512GB ROM and a processor of A12 bionic chip with a display of 6.5 inches",
                    Rating = 8.8M
                },
                new Product
                {
                    Id = 15,
                    Name = "iPhoneXS",
                    Price = 49900,
                    Description = "It has a 6GB Ram/128GB ROM and a processor of A12 bionic chip with a display of 5.8 inches",
                    Rating = 8.3M
                },
                new Product
                {
                    Id = 16,
                    Name = "iPhoneXR",
                    Price = 45900,
                    Description = "It has a 8GB Ram/64GB ROM and a processor of A12 bionic chip with a display of 6.1 inches",
                    Rating = 8.1M
                },
                new Product
                {
                    Id = 17,
                    Name = "iPhone8Plus",
                    Price = 40900,
                    Description = "It has a 6GB Ram/128GB ROM and a processor of A11 bionic chip with a display of 5.5 inches",
                    Rating = 7.9M
                },
                new Product
                {
                    Id = 18,
                    Name = "iPhone8",
                    Price = 38900,
                    Description = "It has a 4GB Ram/64GB ROM and a processor of A11 bionic chip with a display of 4.7 inches",
                    Rating = 7.5M
                },
                new Product
                {
                    Id = 19,
                    Name = "iPhone7Plus",
                    Price = 35900,
                    Description = "It has a 4GB Ram/128GB ROM and a processor of A10 bionic chip with a display of 5.4 inches",
                    Rating = 7.6M
                },
                new Product
                {
                    Id = 20,
                    Name = "iPhone7",
                    Price = 33900,
                    Description = "It has a 4GB Ram/64GB ROM and a processor of A10 bionic chip with a display of 4.7 inches",
                    Rating = 7.2M
                },
                new Product
                {
                    Id = 21,
                    Name = "iPadPro",
                    Price = 71900,
                    Description = "It has a 8GB Ram/128GB ROM and a processor of M1 chip with a display of 11 inches",
                    Rating = 9.5M
                },
                new Product
                {
                    Id = 22,
                    Name = "iPadAir",
                    Price = 54900,
                    Description = "It has a 6GB Ram/64GB ROM and a processor of A14 bionic chip with a display of 10.9 inches",
                    Rating = 9.1M
                },
                new Product
                {
                    Id = 23,
                    Name = "iPad",
                    Price = 46900,
                    Description = "It has a 6GB Ram/128GB ROM and a processor of A13 bionic chip with a display of 10.2 inches",
                    Rating = 8.7M
                },
                 new Product
                 {
                     Id = 24,
                     Name = "iPadMini",
                     Price = 35900,
                     Description = "It has a 4 GB Ram,64 GB of ROM and a processor of A15 bionic chip with a display of 8.3 inches",
                     Rating = 8.5M
                 }
            );

        }
    }
}
