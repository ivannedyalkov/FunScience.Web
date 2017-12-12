namespace FunScience.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class SchoolMapLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Lng",
                table: "Schools",
                type: "decimal(18,12)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                table: "Schools",
                type: "decimal(18,12)",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Lng",
                table: "Schools",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,12)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                table: "Schools",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,12)");
        }
    }
}
