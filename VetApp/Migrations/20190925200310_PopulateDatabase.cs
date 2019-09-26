using Microsoft.EntityFrameworkCore.Migrations;

namespace VetApp.Migrations
{
    public partial class PopulateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO Owners (Name, Birthday, Contact) VALUES ('Pedro Duarte','1998-01-31 00:00:00' , '962027094')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}