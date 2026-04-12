using Microsoft.EntityFrameworkCore;
using Retail_Backend.model;


namespace Retail_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tables
        public DbSet<User> Users { get; set; }
        //public DbSet<MenuItem> MenuItems { get; set; }
        //public DbSet<Cart> Carts { get; set; }
        //public DbSet<Order> Orders { get; set; }
    }
}