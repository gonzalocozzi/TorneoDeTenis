using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorneoDeTenis.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Partido_Fecha_Torneo_TipoTorneo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoTorneo",
                table: "Enfrentamiento",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoTorneo",
                table: "Enfrentamiento");
        }
    }
}
