using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalServicesWebApp.Contexts;
using CarRentalServicesWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalServicesWebApp.Contexts
{
    public class Context : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Client> Clients { get; set; }

        public static bool isMigration = true;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (isMigration)
            {
                optionsBuilder.UseSqlServer(@"Server=.\;Database = DBCarRentalServicesWebApp;Trusted_Connection=True");
            }
        }
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}

