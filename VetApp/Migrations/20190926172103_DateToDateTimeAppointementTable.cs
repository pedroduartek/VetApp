using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetApp.Migrations
{
    public partial class DateToDateTimeAppointementTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Appointments",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Appointments",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
