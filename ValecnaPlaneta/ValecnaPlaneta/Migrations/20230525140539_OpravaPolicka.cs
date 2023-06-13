using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValecnaPlaneta.Migrations
{
    /// <inheritdoc />
    public partial class OpravaPolicka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stav",
                table: "Policka",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stav",
                table: "Policka");
        }
    }
}
