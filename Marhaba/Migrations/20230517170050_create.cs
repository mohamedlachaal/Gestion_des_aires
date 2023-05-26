using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marhaba.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passagers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "villes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_villes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "aires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VilleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_aires_villes_VilleId",
                        column: x => x.VilleId,
                        principalTable: "villes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    AireId = table.Column<int>(type: "int", nullable: false),
                    PassagerId = table.Column<int>(type: "int", nullable: false),
                    DateReservation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => new { x.AireId, x.PassagerId });
                    table.ForeignKey(
                        name: "FK_reservations_aires_AireId",
                        column: x => x.AireId,
                        principalTable: "aires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_Passagers_PassagerId",
                        column: x => x.PassagerId,
                        principalTable: "Passagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aires_VilleId",
                table: "aires",
                column: "VilleId");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_PassagerId",
                table: "reservations",
                column: "PassagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "aires");

            migrationBuilder.DropTable(
                name: "Passagers");

            migrationBuilder.DropTable(
                name: "villes");
        }
    }
}
