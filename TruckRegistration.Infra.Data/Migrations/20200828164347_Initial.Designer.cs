﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TruckRegistration.Infra.Data.Contexts;

namespace TruckRegistration.Infra.Data.Migrations
{
    [DbContext(typeof(TruckRegistrationContext))]
    [Migration("20200828164347_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TruckRegistration.Domain.Entities.Truck", b =>
                {
                    b.Property<int>("TruckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TruckModelId")
                        .HasColumnType("int");

                    b.Property<int>("YearManufacture")
                        .HasColumnName("year_manufacture")
                        .HasColumnType("int");

                    b.Property<int>("YearModel")
                        .HasColumnName("year_madel")
                        .HasColumnType("int");

                    b.HasKey("TruckId");

                    b.HasIndex("TruckModelId");

                    b.ToTable("tb_truck");
                });

            modelBuilder.Entity("TruckRegistration.Domain.Entities.TruckModel", b =>
                {
                    b.Property<int>("TruckModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ModelDescription")
                        .HasColumnName("ds_model")
                        .HasColumnType("char(2)");

                    b.HasKey("TruckModelId");

                    b.ToTable("tb_truck_model");
                });

            modelBuilder.Entity("TruckRegistration.Domain.Entities.Truck", b =>
                {
                    b.HasOne("TruckRegistration.Domain.Entities.TruckModel", "Model")
                        .WithMany("Trucks")
                        .HasForeignKey("TruckModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
