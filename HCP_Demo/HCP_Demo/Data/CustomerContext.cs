using HCP_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace HCP_Demo.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Force singular naming on the tables.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Favorite>().ToTable("Favorite");
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }
    }
}