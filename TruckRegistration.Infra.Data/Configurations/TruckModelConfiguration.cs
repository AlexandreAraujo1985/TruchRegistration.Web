using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Infra.Data.Configurations
{
    public class TruckModelConfiguration : IEntityTypeConfiguration<TruckModel>
    {
        public void Configure(EntityTypeBuilder<TruckModel> builder)
        {
            builder.ToTable("tb_truck_model");

            builder.HasKey(x => x.TruckModelId);

            builder.Property(x => x.ModelDescription)
               .HasColumnType("char(2)").HasColumnName("ds_model");

            builder.HasMany(t => t.Trucks)
                .WithOne(x => x.Model);
        }
    }
}
