using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValecnaPlaneta.Migrations
{
    /// <inheritdoc />
    public partial class PrvniAleNeTakDocelaPrvniMigrace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soukroma = table.Column<bool>(type: "bit", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jmeno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Heslo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hraci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HraKamPatriId = table.Column<int>(type: "int", nullable: false),
                    Zije = table.Column<bool>(type: "bit", nullable: false),
                    Kapital = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasPosledniAkce = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hraci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hraci_Hry_HraKamPatriId",
                        column: x => x.HraKamPatriId,
                        principalTable: "Hry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Policka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<int>(type: "int", nullable: false),
                    HraKamPatriId = table.Column<int>(type: "int", nullable: false),
                    Stav = table.Column<int>(type: "int", nullable: false),
                    Vlastnik = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policka_Hry_HraKamPatriId",
                        column: x => x.HraKamPatriId,
                        principalTable: "Hry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hraci_HraKamPatriId",
                table: "Hraci",
                column: "HraKamPatriId");

            migrationBuilder.CreateIndex(
                name: "IX_Policka_HraKamPatriId",
                table: "Policka",
                column: "HraKamPatriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hraci");

            migrationBuilder.DropTable(
                name: "Policka");

            migrationBuilder.DropTable(
                name: "Hry");
        }
    }
}
