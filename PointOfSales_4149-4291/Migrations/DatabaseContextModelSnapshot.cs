﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PointOfSales_4149_4291.Database;

#nullable disable

namespace PointOfSales_4149_4291.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2");

            modelBuilder.Entity("PointOfSales_4149_4291.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NicNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Totle")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Customers_table");
                });

            modelBuilder.Entity("PointOfSales_4149_4291.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("DiscountPercentage")
                        .HasColumnType("REAL");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("NIC")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Items_table");
                });

            modelBuilder.Entity("PointOfSales_4149_4291.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserAndAdmins_list");
                });
#pragma warning restore 612, 618
        }
    }
}
