using CoolatyMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoolatyMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ShopingCart> ShopingCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShippingService> ShippingServices { get; set; }
        public DbSet<Shipping> Shipping { get; set; }
        public DbSet<ShippingServiceJunction> ShippingServiceJunctions { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
    }
}