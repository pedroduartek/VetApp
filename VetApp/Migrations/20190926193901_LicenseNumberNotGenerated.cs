using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetApp.Migrations
{
    public partial class LicenseNumberNotGenerated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("LicenseNumber","Doctors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
