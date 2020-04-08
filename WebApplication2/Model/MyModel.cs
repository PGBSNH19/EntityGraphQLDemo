using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Location>().HasData(
                new Location()
                {
                    Id = 3,
                    Name = "My nice location"
                }
            );
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
    }

    public class Property
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public PropertyType Type { get; set; }
        public Location Location { get; set; }
    }

    public class PropertyType
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public decimal Premium { get; set; }
    }

    public class Location
    {
        public uint Id { get; set; }
        public string Name { get; set; }
    }
}
