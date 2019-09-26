using Microsoft.EntityFrameworkCore.Migrations;

namespace VetApp.Migrations
{
    public partial class PopulateDatabaseMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO Owners (Name, Birthday, Contact) VALUES ('Miguel Duarte','2005-01-31 00:00:00' , '123456789')");
            migrationBuilder.Sql(
                "INSERT INTO Owners (Name, Birthday, Contact) VALUES ('David Duarte','1969-06-01 00:00:00' , '987654321')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}