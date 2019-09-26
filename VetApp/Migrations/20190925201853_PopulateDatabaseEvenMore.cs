using Microsoft.EntityFrameworkCore.Migrations;

namespace VetApp.Migrations
{
    public partial class PopulateDatabaseEvenMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO Pets (Name, Birthday, OwnerId, PetType) VALUES ('Dust','2018-01-31 00:00:00' , '3', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}