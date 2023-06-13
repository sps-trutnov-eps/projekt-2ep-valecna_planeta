using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValecnaPlaneta.Migrations
{
    /// <inheritdoc />
    public partial class JmenoHry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Jmeno",
                table: "Hry",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jmeno",
                table: "Hry");
        }
    }
}
