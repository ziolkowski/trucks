using Microsoft.EntityFrameworkCore;
using Trucks.Model;

namespace Trucks.Database
{
    public class TruckContext : DbContext
    {
        private readonly IConfiguration _config;

        public TruckContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Truck> Trucks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_config.GetValue<string>("DataBaseConnectionString"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
