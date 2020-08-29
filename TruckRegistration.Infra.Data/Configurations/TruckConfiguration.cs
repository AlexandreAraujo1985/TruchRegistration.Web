using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Infra.Data.Configurations
{
    public class TruckConfiguration : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable("tb_truck");

            builder.HasKey(x => x.TruckId);

            builder.Property(x => x.NameTruck)
               .HasColumnType("varchar(100)").HasColumnName("name_truck");

            builder.Property(x => x.YearModel)
               .HasColumnType("int").HasColumnName("year_madel");

            builder.Property(x => x.YearManufacture)
                .HasColumnType("int").HasColumnName("year_manufacture");

            builder.HasOne(t => t.Model)
                .WithMany(u => u.Trucks);
        }
    }
}
