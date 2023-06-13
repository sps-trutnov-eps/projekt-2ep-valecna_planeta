using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValecnaPlaneta.Migrations
{
    /// <inheritdoc />
    public partial class IndexPolicek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Policka",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Hraci",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "Policka");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Hraci");
        }
    }
}
