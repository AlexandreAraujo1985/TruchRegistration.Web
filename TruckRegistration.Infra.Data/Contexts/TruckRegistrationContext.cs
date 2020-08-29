using Microsoft.EntityFrameworkCore;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Infra.Data.Configurations;

namespace TruckRegistration.Infra.Data.Contexts
{
    public class TruckRegistrationContext : DbContext
    {
        public TruckRegistrationContext(DbContextOptions<TruckRegistrationContext> options) : base(options) { }

        public DbSet<Truck> Trucks { get; set; }
        public DbSet<TruckModel> TruckModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TruckConfiguration());
            modelBuilder.ApplyConfiguration(new TruckModelConfiguration());
        }

        //RepositoryTest
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(databaseName: "TruckRegistrationTest");
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
    }
}
