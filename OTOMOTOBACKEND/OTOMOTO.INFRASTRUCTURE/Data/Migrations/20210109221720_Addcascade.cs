using Microsoft.EntityFrameworkCore.Migrations;

namespace OTOMOTO.INFRASTRUCTURE.Data.Migrations
{
    public partial class Addcascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Cars_CarId",
                table: "Pictures");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Pictures",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Cars_CarId",
                table: "Pictures",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Cars_CarId",
                table: "Pictures");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Pictures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Cars_CarId",
                table: "Pictures",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
