using Microsoft.EntityFrameworkCore.Migrations;

namespace OTOMOTO.INFRASTRUCTURE.Data.Migrations
{
    public partial class removeUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_appUserId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_appUserId",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "appUserId",
                table: "Cars",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "appUserId",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
