using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Migrations
{
    /// <inheritdoc />
    public partial class seedingUrl2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/I/71qaGnOxACL._AC_UF1000,1000_QL80_.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.lg.com%2Fin%2Fmicrowave-ovens%2Flg-MC2846SL&psig=AOvVaw0wWRH-SLvcEveCKtg15vHV&ust=1694894954464000&source=images&cd=vfe&opi=89978449&ved=0CBAQjRxqFwoTCKie3--1rYEDFQAAAAAdAAAAABAJ");
        }
    }
}
