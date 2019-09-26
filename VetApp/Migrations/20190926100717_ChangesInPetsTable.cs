using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetApp.Migrations
{
    public partial class ChangesInPetsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                "Birthday",
                "Pets",
                "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                "Birthday",
                "Owners",
                "Date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                "Birthday",
                "Pets",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                "Birthday",
                "Owners",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }
    }
}