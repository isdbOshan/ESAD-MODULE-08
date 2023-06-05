﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationSecond22.Models;

#nullable disable

namespace WebApplicationSecond22.Migrations
{
    [DbContext(typeof(CarInformationDbContext))]
    partial class CarInformationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplicationSecond22.Models.CarDetail", b =>
                {
                    b.Property<int>("CarDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarDetailId"));

                    b.Property<string>("CarName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsStock")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LaunchDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("CarDetailId");

                    b.ToTable("CarDetails");
                });

            modelBuilder.Entity("WebApplicationSecond22.Models.PartsDetail", b =>
                {
                    b.Property<int>("PartsDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartsDetailId"));

                    b.Property<int>("CarDetailId")
                        .HasColumnType("int");

                    b.Property<string>("PartName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PartsPrice")
                        .HasColumnType("money");

                    b.HasKey("PartsDetailId");

                    b.HasIndex("CarDetailId");

                    b.ToTable("PartsDetails");
                });

            modelBuilder.Entity("WebApplicationSecond22.Models.PartsDetail", b =>
                {
                    b.HasOne("WebApplicationSecond22.Models.CarDetail", "CarDetail")
                        .WithMany("PartsDetails")
                        .HasForeignKey("CarDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarDetail");
                });

            modelBuilder.Entity("WebApplicationSecond22.Models.CarDetail", b =>
                {
                    b.Navigation("PartsDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
