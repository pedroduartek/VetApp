﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace VetApp.Migrations
{
    public partial class ContactToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "Contact",
                "Owners",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                "Contact",
                "Owners",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}