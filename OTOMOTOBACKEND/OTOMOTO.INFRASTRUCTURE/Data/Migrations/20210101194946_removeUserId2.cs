using Microsoft.EntityFrameworkCore.Migrations;

namespace OTOMOTO.INFRASTRUCTURE.Data.Migrations
{
    public partial class removeUserId2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "appUserId",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "appUserId",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
