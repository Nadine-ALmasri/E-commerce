using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Migrations
{
    /// <inheritdoc />
    public partial class seedingUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.lg.com%2Fin%2Fmicrowave-ovens%2Flg-MC2846SL&psig=AOvVaw0wWRH-SLvcEveCKtg15vHV&ust=1694894954464000&source=images&cd=vfe&opi=89978449&ved=0CBAQjRxqFwoTCKie3--1rYEDFQAAAAAdAAAAABAJ");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://longeatonappliances.co.uk/wp-content/uploads/2021/04/smv4hvx38g.jpg");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://www.bing.com/images/search?view=detailV2&ccid=Ao8YcK6t&id=2C1E1687CFBD43C8698D6F5659510F6A17BA1DC3&thid=OIP.Ao8YcK6tWt8d8JVTA1J91AHaHa&mediaurl=https%3a%2f%2fwww.bhphotovideo.com%2fimages%2fimages2500x2500%2fsamsung_hg43nj470mfxza_43_470_series_full_1444284.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.028f1870aead5adf1df0955303527dd4%3frik%3dwx26F2oPUVlWbw%26pid%3dImgRaw%26r%3d0&exph=2500&expw=2500&q=samsung+tv&simid=608040461989200792&FORM=IRPRST&ck=4319176676534CADD333DE27C0446661&selectedIndex=1");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://www.bing.com/images/search?view=detailV2&ccid=QZRDX0P1&id=EA04027D8A449D5095FBC88D989F9C29E98794FA&thid=OIP.QZRDX0P1o7Pfswsyk9pA5AHaHa&mediaurl=https%3a%2f%2fwww.bhphotovideo.com%2fimages%2fimages2500x2500%2fsamsung_sm_t380nzkexar_8_0_tab_a_8_0_1363546.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.4194435f43f5a3b3dfb30b3293da40e4%3frik%3d%252bpSH6Smcn5iNyA%26pid%3dImgRaw%26r%3d0&exph=2500&expw=2500&q=SAMSUNG+Galaxy+Tab+A8&simid=607997091423989576&FORM=IRPRST&ck=23A2F0EFA68BAE47D447D01D91A0FD37&selectedIndex=2");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://www.bing.com/images/search?view=detailV2&ccid=IUaw2DIA&id=C2A654B6E576FBFBAEC770E1A43D6D7CED8F2A72&thid=OIP.IUaw2DIAAE7KHbt3MUkudwHaHa&mediaurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.2146b0d83200004eca1dbb7731492e77%3frik%3dciqP7XxtPaThcA%26riu%3dhttp%253a%252f%252fimages.chickadvisor.com%252fitem%252f2911%252foriginal%252fa1e9cc36fa3678ec8624377b41f9ec23.jpg%26ehk%3d3pGJs1RCFKTTmQ0Ha%252bQ9Skwrh3aiET0Gt6G9bM9lwnI%253d%26risl%3d%26pid%3dImgRaw%26r%3d0&exph=1000&expw=1000&q=Maybelline+Mascara&simid=607986371212023103&FORM=IRPRST&ck=2206643943BA3E4D8F5E36A698C6EA2F&selectedIndex=2");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://www.bing.com/images/search?view=detailV2&ccid=1JRE%2bu7d&id=B998B5F4D67B37F04B7AAA141D6A29ADB43F5B63&thid=OIP.1JRE-u7dKu8XMd9zEGI_yQHaFF&mediaurl=https%3a%2f%2fpisces.bbystatic.com%2fimage2%2fBestBuy_US%2fimages%2fproducts%2f6170%2f6170703_sd.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.d49444faeedd2aef1731df7310623fc9%3frik%3dY1s%252ftK0pah0Uqg%26pid%3dImgRaw%26r%3d0&exph=813&expw=1184&q=acer+2023+Newest+Chromebook+15.6&simid=607996769307082530&FORM=IRPRST&ck=7C9DB0F6618896E2BD2D321B20A25CDF&selectedIndex=3");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://th.bing.com/th/id/R.159a99ed1bb4a1aadbf8b0eb25ac58f9?rik=YZUjrgNfX3Hjfw&pid=ImgRaw&r=0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "");
        }
    }
}
