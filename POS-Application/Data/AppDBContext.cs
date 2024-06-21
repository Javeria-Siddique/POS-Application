using POSApp.Entities;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace POSApp.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDB");
        }
    }
}