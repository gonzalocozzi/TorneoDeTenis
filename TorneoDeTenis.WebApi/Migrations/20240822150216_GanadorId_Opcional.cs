using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorneoDeTenis.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class GanadorId_Opcional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enfrentamiento_Jugadores_GanadorId",
                table: "Enfrentamiento");

            migrationBuilder.AlterColumn<long>(
                name: "GanadorId",
                table: "Enfrentamiento",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Enfrentamiento_Jugadores_GanadorId",
                table: "Enfrentamiento",
                column: "GanadorId",
                principalTable: "Jugadores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enfrentamiento_Jugadores_GanadorId",
                table: "Enfrentamiento");

            migrationBuilder.AlterColumn<long>(
                name: "GanadorId",
                table: "Enfrentamiento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enfrentamiento_Jugadores_GanadorId",
                table: "Enfrentamiento",
                column: "GanadorId",
                principalTable: "Jugadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
