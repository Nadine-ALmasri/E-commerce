using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce.Migrations
{
    /// <inheritdoc />
    public partial class buildTheDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => new { x.Id, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartProducts_Cart_Id",
                        column: x => x.Id,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "administrator", "00000000-0000-0000-0000-000000000000", "Administrator", "ADMINISTRATOR" },
                    { "editor", "00000000-0000-0000-0000-000000000000", "Editor", "EDITOR" },
                    { "user", "00000000-0000-0000-0000-000000000000", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Computers & Tablets" },
                    { 3, "Makeup" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Great , Large ,A++ electricity consuming", "https://m.media-amazon.com/images/I/71qaGnOxACL._AC_UF1000,1000_QL80_.jpg", "LG Microwave", 155.0 },
                    { 2, 1, "cleaning dishes in a foodservice environment to ensure that there is always plenty of clean tableware at hand", "https://longeatonappliances.co.uk/wp-content/uploads/2021/04/smv4hvx38g.jpg", "Dish Washer", 450.0 },
                    { 3, 1, "75\" Neo QLED 4K HDR Screen", "https://www.bing.com/images/search?view=detailV2&ccid=Ao8YcK6t&id=2C1E1687CFBD43C8698D6F5659510F6A17BA1DC3&thid=OIP.Ao8YcK6tWt8d8JVTA1J91AHaHa&mediaurl=https%3a%2f%2fwww.bhphotovideo.com%2fimages%2fimages2500x2500%2fsamsung_hg43nj470mfxza_43_470_series_full_1444284.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.028f1870aead5adf1df0955303527dd4%3frik%3dwx26F2oPUVlWbw%26pid%3dImgRaw%26r%3d0&exph=2500&expw=2500&q=samsung+tv&simid=608040461989200792&FORM=IRPRST&ck=4319176676534CADD333DE27C0446661&selectedIndex=1", "SAMSUNG TV ", 500.0 },
                    { 4, 2, "SAMSUNG Galaxy Tab A8 10.5” 32GB Android Tablet, LCD Screen, Kids Content, Smart Switch, Long Lasting Battery, US Version, 2022, Dark Gray", "https://www.bing.com/images/search?view=detailV2&ccid=QZRDX0P1&id=EA04027D8A449D5095FBC88D989F9C29E98794FA&thid=OIP.QZRDX0P1o7Pfswsyk9pA5AHaHa&mediaurl=https%3a%2f%2fwww.bhphotovideo.com%2fimages%2fimages2500x2500%2fsamsung_sm_t380nzkexar_8_0_tab_a_8_0_1363546.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.4194435f43f5a3b3dfb30b3293da40e4%3frik%3d%252bpSH6Smcn5iNyA%26pid%3dImgRaw%26r%3d0&exph=2500&expw=2500&q=SAMSUNG+Galaxy+Tab+A8&simid=607997091423989576&FORM=IRPRST&ck=23A2F0EFA68BAE47D447D01D91A0FD37&selectedIndex=2", "SAMSUNG Galaxy Tab A8", 170.0 },
                    { 5, 3, " Lash Sensational Sky High Washable ,Volumizing, Lengthening, Defining,", "https://www.bing.com/images/search?view=detailV2&ccid=IUaw2DIA&id=C2A654B6E576FBFBAEC770E1A43D6D7CED8F2A72&thid=OIP.IUaw2DIAAE7KHbt3MUkudwHaHa&mediaurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.2146b0d83200004eca1dbb7731492e77%3frik%3dciqP7XxtPaThcA%26riu%3dhttp%253a%252f%252fimages.chickadvisor.com%252fitem%252f2911%252foriginal%252fa1e9cc36fa3678ec8624377b41f9ec23.jpg%26ehk%3d3pGJs1RCFKTTmQ0Ha%252bQ9Skwrh3aiET0Gt6G9bM9lwnI%253d%26risl%3d%26pid%3dImgRaw%26r%3d0&exph=1000&expw=1000&q=Maybelline+Mascara&simid=607986371212023103&FORM=IRPRST&ck=2206643943BA3E4D8F5E36A698C6EA2F&selectedIndex=2", "Maybelline Mascara", 24.0 },
                    { 7, 2, "acer 2023 Newest Chromebook 15.6\" FHD 1080p IPS Touchscreen Light Computer Laptop, Due-core Intel Celeron N4020, 4GB RAM, 64GB", "https://www.bing.com/images/search?view=detailV2&ccid=1JRE%2bu7d&id=B998B5F4D67B37F04B7AAA141D6A29ADB43F5B63&thid=OIP.1JRE-u7dKu8XMd9zEGI_yQHaFF&mediaurl=https%3a%2f%2fpisces.bbystatic.com%2fimage2%2fBestBuy_US%2fimages%2fproducts%2f6170%2f6170703_sd.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.d49444faeedd2aef1731df7310623fc9%3frik%3dY1s%252ftK0pah0Uqg%26pid%3dImgRaw%26r%3d0&exph=813&expw=1184&q=acer+2023+Newest+Chromebook+15.6&simid=607996769307082530&FORM=IRPRST&ck=7C9DB0F6618896E2BD2D321B20A25CDF&selectedIndex=3", "acer 2023 Newest Chromebook 15.6\"", 205.0 },
                    { 8, 3, ", Waterproof Liquid Eyeliner - Black, Vegan Formula", "https://th.bing.com/th/id/R.159a99ed1bb4a1aadbf8b0eb25ac58f9?rik=YZUjrgNfX3Hjfw&pid=ImgRaw&r=0", "NYX PROFESSIONAL MAKEUP Epic Ink Liner", 9.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_ProductId",
                table: "CartProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
