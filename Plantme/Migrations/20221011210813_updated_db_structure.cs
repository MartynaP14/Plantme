using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plantme.Migrations
{
    public partial class updated_db_structure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Products_ProductId",
                table: "ProductOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrder_ProductId",
                table: "ProductOrder");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductOrder");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "ProductOrder",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderItemInfo",
                columns: table => new
                {
                    OrderItemInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductOrderID = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemInfo", x => x.OrderItemInfoId);
                    table.ForeignKey(
                        name: "FK_OrderItemInfo_ProductOrder_ProductOrderID",
                        column: x => x.ProductOrderID,
                        principalTable: "ProductOrder",
                        principalColumn: "ProductOrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemInfo_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_Id",
                table: "ProductOrder",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemInfo_ProductId",
                table: "OrderItemInfo",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemInfo_ProductOrderID",
                table: "OrderItemInfo",
                column: "ProductOrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Users_Id",
                table: "ProductOrder",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Users_Id",
                table: "ProductOrder");

            migrationBuilder.DropTable(
                name: "OrderItemInfo");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrder_Id",
                table: "ProductOrder");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductOrder");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_ProductId",
                table: "ProductOrder",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Products_ProductId",
                table: "ProductOrder",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_Id",
                table: "Products",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
