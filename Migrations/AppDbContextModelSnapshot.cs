﻿// <auto-generated />
using ECommerceProductSorting.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerceProductSorting.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerceProductSorting.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Apple",
                            Category = "Phones",
                            Name = "iPhone 14",
                            Price = 999m,
                            Rating = 4.5
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Samsung",
                            Category = "Phones",
                            Name = "Galaxy S23",
                            Price = 829m,
                            Rating = 4.2999999999999998
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Apple",
                            Category = "Laptops",
                            Name = "MacBook Air1",
                            Price = 1299m,
                            Rating = 4.7999999999999998
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Dell",
                            Category = "Laptops",
                            Name = "Dell XPSf",
                            Price = 1099m,
                            Rating = 4.5999999999999996
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Apple",
                            Category = "Phones",
                            Name = "iPhone 15",
                            Price = 989m,
                            Rating = 3.5
                        },
                        new
                        {
                            Id = 6,
                            Brand = "Samsung",
                            Category = "Phones",
                            Name = "Galaxy S24",
                            Price = 859m,
                            Rating = 2.2999999999999998
                        },
                        new
                        {
                            Id = 7,
                            Brand = "Apple",
                            Category = "Laptops",
                            Name = "MacBook Air2",
                            Price = 1599m,
                            Rating = 1.8
                        },
                        new
                        {
                            Id = 8,
                            Brand = "Dell",
                            Category = "Laptops",
                            Name = "Dell XPSd",
                            Price = 1099m,
                            Rating = 4.2999999999999998
                        },
                        new
                        {
                            Id = 9,
                            Brand = "Apple",
                            Category = "Phones",
                            Name = "iPhone 16",
                            Price = 979m,
                            Rating = 3.6000000000000001
                        },
                        new
                        {
                            Id = 10,
                            Brand = "Samsung",
                            Category = "Phones",
                            Name = "Galaxy S25",
                            Price = 809m,
                            Rating = 4.0999999999999996
                        },
                        new
                        {
                            Id = 11,
                            Brand = "Apple",
                            Category = "Laptops",
                            Name = "MacBook Air3",
                            Price = 1499m,
                            Rating = 2.1000000000000001
                        },
                        new
                        {
                            Id = 12,
                            Brand = "Dell",
                            Category = "Laptops",
                            Name = "Dell XPSw",
                            Price = 1099m,
                            Rating = 4.9000000000000004
                        },
                        new
                        {
                            Id = 13,
                            Brand = "Apple",
                            Category = "Phones",
                            Name = "iPhone 17",
                            Price = 969m,
                            Rating = 4.5
                        },
                        new
                        {
                            Id = 14,
                            Brand = "Samsung",
                            Category = "Phones",
                            Name = "Galaxy S28",
                            Price = 819m,
                            Rating = 4.2999999999999998
                        },
                        new
                        {
                            Id = 15,
                            Brand = "Apple",
                            Category = "Laptops",
                            Name = "MacBook Air4",
                            Price = 1399m,
                            Rating = 3.3999999999999999
                        },
                        new
                        {
                            Id = 16,
                            Brand = "Dell",
                            Category = "Laptops",
                            Name = "Dell XPSe",
                            Price = 1099m,
                            Rating = 1.1000000000000001
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
