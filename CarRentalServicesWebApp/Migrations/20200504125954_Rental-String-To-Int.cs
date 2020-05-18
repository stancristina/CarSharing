using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalServicesWebApp.Migrations
{
    public partial class RentalStringToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Period",
                table: "Rentals",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Period",
                table: "Rentals",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
