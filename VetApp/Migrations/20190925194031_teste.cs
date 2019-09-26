using Microsoft.EntityFrameworkCore.Migrations;

namespace VetApp.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "PetId",
                "Owners",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "PetId",
                "Owners");
        }
    }
}