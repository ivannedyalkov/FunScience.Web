namespace FunScience.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class PlayNameRestrictive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Plays_Name",
                table: "Plays",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Plays_Name",
                table: "Plays");
        }
    }
}
