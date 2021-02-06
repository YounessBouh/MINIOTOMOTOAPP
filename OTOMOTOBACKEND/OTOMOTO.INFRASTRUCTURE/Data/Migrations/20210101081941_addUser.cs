using Microsoft.EntityFrameworkCore.Migrations;

namespace OTOMOTO.INFRASTRUCTURE.Data.Migrations
{
    public partial class addUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Home",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "appUserId",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_appUserId",
                table: "Cars",
                column: "appUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_appUserId",
                table: "Cars",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_appUserId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_appUserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "appUserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Home",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
