using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plantme.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                table: "Products",
                newName: "IX_Products_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_Id",
                table: "Products",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_Id",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Id",
                table: "Products",
                newName: "IX_Products_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
