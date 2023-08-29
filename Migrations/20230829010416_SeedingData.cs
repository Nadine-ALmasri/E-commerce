using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Great , Large ,A++ electricity consuming", "LG Microwave", 155.0 },
                    { 2, 1, "cleaning dishes in a foodservice environment to ensure that there is always plenty of clean tableware at hand", "Dish Washer", 450.0 },
                    { 3, 1, "75\" Neo QLED 4K HDR Screen", "SAMSUNG TV ", 500.0 },
                    { 4, 2, "SAMSUNG Galaxy Tab A8 10.5” 32GB Android Tablet, LCD Screen, Kids Content, Smart Switch, Long Lasting Battery, US Version, 2022, Dark Gray", "SAMSUNG Galaxy Tab A8", 170.0 },
                    { 5, 3, " Lash Sensational Sky High Washable ,Volumizing, Lengthening, Defining,", "Maybelline Mascara", 24.0 },
                    { 6, 2, "Scott International Men's Regular", "NYX PROFESSIONAL MAKEUP Epic Ink Liner", 120.0 },
                    { 7, 2, "acer 2023 Newest Chromebook 15.6\" FHD 1080p IPS Touchscreen Light Computer Laptop, Due-core Intel Celeron N4020, 4GB RAM, 64GB", "acer 2023 Newest Chromebook 15.6\"", 205.0 },
                    { 8, 3, ", Waterproof Liquid Eyeliner - Black, Vegan Formula", "NYX PROFESSIONAL MAKEUP Epic Ink Liner", 9.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
