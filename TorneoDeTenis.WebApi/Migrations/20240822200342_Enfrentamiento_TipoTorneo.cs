using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorneoDeTenis.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Enfrentamiento_TipoTorneo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoTorneo",
                table: "Enfrentamiento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoTorneo",
                table: "Enfrentamiento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
