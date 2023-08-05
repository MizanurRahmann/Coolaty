using CoolatyMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoolatyMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //  DBSETS
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ShopingCart> ShopingCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShippingService> ShippingServices { get; set; }
        public DbSet<Shipping> Shipping { get; set; }
        public DbSet<ShippingServiceJunction> ShippingServiceJunctions { get; set; }

        // OVERRIDE ONMODELCREATING
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // define the composit primary key for ShippingServiceJunction table
            builder.Entity<ShippingServiceJunction>().HasKey(sf => new {sf.ShippingId, sf.ServiceId});
        }
    }
}