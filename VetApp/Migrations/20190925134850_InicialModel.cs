using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetApp.Migrations
{
    public partial class InicialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Owners",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Contact = table.Column<int>(nullable: false),
                    PetId = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Owners", x => x.Id); });

            migrationBuilder.CreateTable(
                "Pets",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    PetType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        "FK_Pets_Owners_OwnerId",
                        x => x.OwnerId,
                        "Owners",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Pets_OwnerId",
                "Pets",
                "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Pets");

            migrationBuilder.DropTable(
                "Owners");
        }
    }
}