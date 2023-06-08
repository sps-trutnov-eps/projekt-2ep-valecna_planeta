using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValecnaPlaneta.Migrations
{
    /// <inheritdoc />
    public partial class UpravaVlastnikaPolicek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policka_Hry_HraKamPatriId",
                table: "Policka");

            migrationBuilder.DropColumn(
                name: "Vlastnik",
                table: "Policka");

            migrationBuilder.AlterColumn<int>(
                name: "HraKamPatriId",
                table: "Policka",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "VlastnikId",
                table: "Policka",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Policka_VlastnikId",
                table: "Policka",
                column: "VlastnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Policka_Hraci_VlastnikId",
                table: "Policka",
                column: "VlastnikId",
                principalTable: "Hraci",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Policka_Hry_HraKamPatriId",
                table: "Policka",
                column: "HraKamPatriId",
                principalTable: "Hry",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policka_Hraci_VlastnikId",
                table: "Policka");

            migrationBuilder.DropForeignKey(
                name: "FK_Policka_Hry_HraKamPatriId",
                table: "Policka");

            migrationBuilder.DropIndex(
                name: "IX_Policka_VlastnikId",
                table: "Policka");

            migrationBuilder.DropColumn(
                name: "VlastnikId",
                table: "Policka");

            migrationBuilder.AlterColumn<int>(
                name: "HraKamPatriId",
                table: "Policka",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vlastnik",
                table: "Policka",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Policka_Hry_HraKamPatriId",
                table: "Policka",
                column: "HraKamPatriId",
                principalTable: "Hry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
