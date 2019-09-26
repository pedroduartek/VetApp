using Microsoft.EntityFrameworkCore.Migrations;

namespace VetApp.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "PetId",
                "Owners");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "PetId",
                "Owners",
                nullable: false,
                defaultValue: 0);
        }
    }
}