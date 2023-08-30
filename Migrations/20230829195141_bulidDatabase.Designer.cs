﻿// <auto-generated />
using E_commerce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_commerce.Migrations
{
    [DbContext(typeof(E_commerceDbContext))]
    [Migration("20230829195141_bulidDatabase")]
    partial class bulidDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_commerce.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Computers & Tablets"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Makeup"
                        });
                });

            modelBuilder.Entity("E_commerce.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Great , Large ,A++ electricity consuming",
                            Name = "LG Microwave",
                            Price = 155.0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "cleaning dishes in a foodservice environment to ensure that there is always plenty of clean tableware at hand",
                            Name = "Dish Washer",
                            Price = 450.0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "75\" Neo QLED 4K HDR Screen",
                            Name = "SAMSUNG TV ",
                            Price = 500.0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "SAMSUNG Galaxy Tab A8 10.5” 32GB Android Tablet, LCD Screen, Kids Content, Smart Switch, Long Lasting Battery, US Version, 2022, Dark Gray",
                            Name = "SAMSUNG Galaxy Tab A8",
                            Price = 170.0
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Description = " Lash Sensational Sky High Washable ,Volumizing, Lengthening, Defining,",
                            Name = "Maybelline Mascara",
                            Price = 24.0
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Description = "acer 2023 Newest Chromebook 15.6\" FHD 1080p IPS Touchscreen Light Computer Laptop, Due-core Intel Celeron N4020, 4GB RAM, 64GB",
                            Name = "acer 2023 Newest Chromebook 15.6\"",
                            Price = 205.0
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Description = ", Waterproof Liquid Eyeliner - Black, Vegan Formula",
                            Name = "NYX PROFESSIONAL MAKEUP Epic Ink Liner",
                            Price = 9.0
                        });
                });

            modelBuilder.Entity("E_commerce.Models.Product", b =>
                {
                    b.HasOne("E_commerce.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_commerce.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
