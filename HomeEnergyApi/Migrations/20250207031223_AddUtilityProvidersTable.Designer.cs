﻿// <auto-generated />
using HomeEnergyApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeEnergyApi.Migrations
{
    [DbContext(typeof(HomeDbContext))]
    [Migration("20250207031223_AddUtilityProvidersTable")]
    partial class AddUtilityProvidersTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("HomeEnergyApi.Models.Home", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnerLastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetAddress")
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Homes");
                });

            modelBuilder.Entity("HomeEnergyApi.Models.HomeUsageData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasSolar")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HomeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MonthlyElectricUsage")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HomeId")
                        .IsUnique();

                    b.ToTable("HomeUsageDatas");
                });

            modelBuilder.Entity("HomeEnergyApi.Models.UtilityProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HomeId")
                        .HasColumnType("INTEGER");

                    b.PrimitiveCollection<string>("ProvidedUtilities")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HomeId");

                    b.ToTable("UtilityProviders");
                });

            modelBuilder.Entity("HomeEnergyApi.Models.HomeUsageData", b =>
                {
                    b.HasOne("HomeEnergyApi.Models.Home", "Home")
                        .WithOne("HomeUsageData")
                        .HasForeignKey("HomeEnergyApi.Models.HomeUsageData", "HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Home");
                });

            modelBuilder.Entity("HomeEnergyApi.Models.UtilityProvider", b =>
                {
                    b.HasOne("HomeEnergyApi.Models.Home", "Home")
                        .WithMany("UtilityProviders")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Home");
                });

            modelBuilder.Entity("HomeEnergyApi.Models.Home", b =>
                {
                    b.Navigation("HomeUsageData");

                    b.Navigation("UtilityProviders");
                });
#pragma warning restore 612, 618
        }
    }
}
