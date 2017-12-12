namespace FunScience.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class SchoolLatLngSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Lng",
                table: "Schools",
                type: "decimal(10,7)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,12)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                table: "Schools",
                type: "decimal(10,7)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,12)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Lng",
                table: "Schools",
                type: "decimal(18,12)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,7)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                table: "Schools",
                type: "decimal(18,12)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,7)");
        }
    }
}
