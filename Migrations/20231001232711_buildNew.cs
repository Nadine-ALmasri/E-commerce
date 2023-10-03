using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Migrations
{
    /// <inheritdoc />
    public partial class buildNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CartEmail_ShoppingCartId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "CartProductDTO");

            migrationBuilder.DropTable(
                name: "CartEmail");

            migrationBuilder.DropTable(
                name: "ProductCategoryEmailDTO");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cart_ShoppingCartId",
                table: "Orders",
                column: "ShoppingCartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cart_ShoppingCartId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "CartEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartEmail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryEmailDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryEmailDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartProductDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CartEmailId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProductDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartProductDTO_CartEmail_CartEmailId",
                        column: x => x.CartEmailId,
                        principalTable: "CartEmail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartProductDTO_ProductCategoryEmailDTO_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductCategoryEmailDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProductDTO_CartEmailId",
                table: "CartProductDTO",
                column: "CartEmailId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProductDTO_ProductId",
                table: "CartProductDTO",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CartEmail_ShoppingCartId",
                table: "Orders",
                column: "ShoppingCartId",
                principalTable: "CartEmail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
