using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlServer(@"Server=DESKTOP-EQ4AUPM\SQLEXPRESS;Database=Recapproject;Trusted_Connection=true;Integrated Security=SSPI;");
           // optionsBuilder.UseSqlServer(@"Server=DESKTOP-EQ4AUPM\SQLEXPRESS;Database=Recapnewdatabase;Trusted_Connection=true;Integrated Security=SSPI;");
        }
        public DbSet<Car> Car { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }

    }
}
