using Microsoft.EntityFrameworkCore.Migrations;

namespace VetApp.Migrations
{
    public partial class PopulateDatabaseEvenMoreAndMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO Pets (Name, Birthday, OwnerId, PetType) VALUES ('Pluto','2000-01-31 00:00:00' , 3, 1)");
            migrationBuilder.Sql(
                "INSERT INTO Pets (Name, Birthday, OwnerId, PetType) VALUES ('Boby','2012-01-31 00:00:00' , 6, 1)");
            migrationBuilder.Sql(
                "INSERT INTO Pets (Name, Birthday, OwnerId, PetType) VALUES ('Pérola','2015-01-31 00:00:00' , 6, 1)");
            migrationBuilder.Sql(
                "INSERT INTO Pets (Name, Birthday, OwnerId, PetType) VALUES ('Piupiu','2019-01-31 00:00:00' , 7, 3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}