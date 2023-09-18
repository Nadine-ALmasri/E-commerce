﻿// <auto-generated />
using System;
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
    [Migration("20230918170624_AddingCart")]
    partial class AddingCart
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_commerce.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("E_commerce.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

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

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Great , Large ,A++ electricity consuming",
                            ImageUrl = "https://m.media-amazon.com/images/I/71qaGnOxACL._AC_UF1000,1000_QL80_.jpg",
                            Name = "LG Microwave",
                            Price = 155.0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "cleaning dishes in a foodservice environment to ensure that there is always plenty of clean tableware at hand",
                            ImageUrl = "https://longeatonappliances.co.uk/wp-content/uploads/2021/04/smv4hvx38g.jpg",
                            Name = "Dish Washer",
                            Price = 450.0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "75\" Neo QLED 4K HDR Screen",
                            ImageUrl = "https://www.bing.com/images/search?view=detailV2&ccid=Ao8YcK6t&id=2C1E1687CFBD43C8698D6F5659510F6A17BA1DC3&thid=OIP.Ao8YcK6tWt8d8JVTA1J91AHaHa&mediaurl=https%3a%2f%2fwww.bhphotovideo.com%2fimages%2fimages2500x2500%2fsamsung_hg43nj470mfxza_43_470_series_full_1444284.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.028f1870aead5adf1df0955303527dd4%3frik%3dwx26F2oPUVlWbw%26pid%3dImgRaw%26r%3d0&exph=2500&expw=2500&q=samsung+tv&simid=608040461989200792&FORM=IRPRST&ck=4319176676534CADD333DE27C0446661&selectedIndex=1",
                            Name = "SAMSUNG TV ",
                            Price = 500.0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "SAMSUNG Galaxy Tab A8 10.5” 32GB Android Tablet, LCD Screen, Kids Content, Smart Switch, Long Lasting Battery, US Version, 2022, Dark Gray",
                            ImageUrl = "https://www.bing.com/images/search?view=detailV2&ccid=QZRDX0P1&id=EA04027D8A449D5095FBC88D989F9C29E98794FA&thid=OIP.QZRDX0P1o7Pfswsyk9pA5AHaHa&mediaurl=https%3a%2f%2fwww.bhphotovideo.com%2fimages%2fimages2500x2500%2fsamsung_sm_t380nzkexar_8_0_tab_a_8_0_1363546.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.4194435f43f5a3b3dfb30b3293da40e4%3frik%3d%252bpSH6Smcn5iNyA%26pid%3dImgRaw%26r%3d0&exph=2500&expw=2500&q=SAMSUNG+Galaxy+Tab+A8&simid=607997091423989576&FORM=IRPRST&ck=23A2F0EFA68BAE47D447D01D91A0FD37&selectedIndex=2",
                            Name = "SAMSUNG Galaxy Tab A8",
                            Price = 170.0
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Description = " Lash Sensational Sky High Washable ,Volumizing, Lengthening, Defining,",
                            ImageUrl = "https://www.bing.com/images/search?view=detailV2&ccid=IUaw2DIA&id=C2A654B6E576FBFBAEC770E1A43D6D7CED8F2A72&thid=OIP.IUaw2DIAAE7KHbt3MUkudwHaHa&mediaurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.2146b0d83200004eca1dbb7731492e77%3frik%3dciqP7XxtPaThcA%26riu%3dhttp%253a%252f%252fimages.chickadvisor.com%252fitem%252f2911%252foriginal%252fa1e9cc36fa3678ec8624377b41f9ec23.jpg%26ehk%3d3pGJs1RCFKTTmQ0Ha%252bQ9Skwrh3aiET0Gt6G9bM9lwnI%253d%26risl%3d%26pid%3dImgRaw%26r%3d0&exph=1000&expw=1000&q=Maybelline+Mascara&simid=607986371212023103&FORM=IRPRST&ck=2206643943BA3E4D8F5E36A698C6EA2F&selectedIndex=2",
                            Name = "Maybelline Mascara",
                            Price = 24.0
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Description = "acer 2023 Newest Chromebook 15.6\" FHD 1080p IPS Touchscreen Light Computer Laptop, Due-core Intel Celeron N4020, 4GB RAM, 64GB",
                            ImageUrl = "https://www.bing.com/images/search?view=detailV2&ccid=1JRE%2bu7d&id=B998B5F4D67B37F04B7AAA141D6A29ADB43F5B63&thid=OIP.1JRE-u7dKu8XMd9zEGI_yQHaFF&mediaurl=https%3a%2f%2fpisces.bbystatic.com%2fimage2%2fBestBuy_US%2fimages%2fproducts%2f6170%2f6170703_sd.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.d49444faeedd2aef1731df7310623fc9%3frik%3dY1s%252ftK0pah0Uqg%26pid%3dImgRaw%26r%3d0&exph=813&expw=1184&q=acer+2023+Newest+Chromebook+15.6&simid=607996769307082530&FORM=IRPRST&ck=7C9DB0F6618896E2BD2D321B20A25CDF&selectedIndex=3",
                            Name = "acer 2023 Newest Chromebook 15.6\"",
                            Price = 205.0
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Description = ", Waterproof Liquid Eyeliner - Black, Vegan Formula",
                            ImageUrl = "https://th.bing.com/th/id/R.159a99ed1bb4a1aadbf8b0eb25ac58f9?rik=YZUjrgNfX3Hjfw&pid=ImgRaw&r=0",
                            Name = "NYX PROFESSIONAL MAKEUP Epic Ink Liner",
                            Price = 9.0
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "administrator",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "editor",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Editor",
                            NormalizedName = "EDITOR"
                        },
                        new
                        {
                            Id = "user",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("E_commerce.Models.Product", b =>
                {
                    b.HasOne("E_commerce.Models.Cart", null)
                        .WithMany("products")
                        .HasForeignKey("CartId");

                    b.HasOne("E_commerce.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("E_commerce.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("E_commerce.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_commerce.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("E_commerce.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_commerce.Models.Cart", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("E_commerce.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
