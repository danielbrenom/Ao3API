using HungryPizzaAPI.Domain.Interfaces;
using HungryPizzaAPI.Domain.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace HungryPizzaAPI.Domain.Configurations
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Tastes> Tastes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tastes>().HasData(
                new Tastes {Id = 1, Name = "3 Queijos", Price = 50f},
                new Tastes {Id = 2, Name = "Frango com requeijão", Price = 59.99f},
                new Tastes {Id = 3, Name = "Mussarela", Price = 42.50f},
                new Tastes {Id = 4, Name = "Calabresa", Price = 42.50f},
                new Tastes {Id = 5, Name = "Pepperoni", Price = 55f},
                new Tastes {Id = 6, Name = "Portuguesa", Price = 45f},
                new Tastes {Id = 7, Name = "Veggie", Price = 59.99f}
            );
        }
    }
}