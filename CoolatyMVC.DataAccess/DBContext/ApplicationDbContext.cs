﻿using CoolatyMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoolatyMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}