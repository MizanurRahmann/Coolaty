using CoolatyMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolatyMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ProductModel> Products { get; set; }
    }
}