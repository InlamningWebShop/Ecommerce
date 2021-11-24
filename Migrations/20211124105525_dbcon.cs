using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom.Migrations
{
    public partial class dbcon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ApplicationUserId",
                table: "Carts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_ApplicationUserId",
                table: "Carts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_ApplicationUserId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ApplicationUserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Carts");
        }
    }
}
