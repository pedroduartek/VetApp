using Microsoft.EntityFrameworkCore.Migrations;

namespace VetApp.Migrations
{
    public partial class PopulateDatabaseEvenMoreAndMoreForgetTheBirds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO Pets (Name, Birthday, OwnerId, PetType) VALUES ('Miau','2018-01-31 00:00:00' , '6', 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}