using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValecnaPlaneta.Migrations
{
    /// <inheritdoc />
    public partial class HraMuzeMitHeslo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Heslo",
                table: "Hry",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Heslo",
                table: "Hry");
        }
    }
}
