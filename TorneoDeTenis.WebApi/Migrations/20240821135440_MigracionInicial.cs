using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorneoDeTenis.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Habilidad = table.Column<int>(type: "int", nullable: false),
                    Fuerza = table.Column<int>(type: "int", nullable: false),
                    Velocidad = table.Column<int>(type: "int", nullable: false),
                    TiempoReaccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enfrentamiento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDeRonda = table.Column<int>(type: "int", nullable: false),
                    GanadorId = table.Column<long>(type: "bigint", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    TorneoId = table.Column<long>(type: "bigint", nullable: true),
                    PrimerJugadorId = table.Column<long>(type: "bigint", nullable: true),
                    SegundoJugadorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfrentamiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enfrentamiento_Enfrentamiento_TorneoId",
                        column: x => x.TorneoId,
                        principalTable: "Enfrentamiento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enfrentamiento_Jugadores_GanadorId",
                        column: x => x.GanadorId,
                        principalTable: "Jugadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enfrentamiento_Jugadores_PrimerJugadorId",
                        column: x => x.PrimerJugadorId,
                        principalTable: "Jugadores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enfrentamiento_Jugadores_SegundoJugadorId",
                        column: x => x.SegundoJugadorId,
                        principalTable: "Jugadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enfrentamiento_GanadorId",
                table: "Enfrentamiento",
                column: "GanadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Enfrentamiento_PrimerJugadorId",
                table: "Enfrentamiento",
                column: "PrimerJugadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Enfrentamiento_SegundoJugadorId",
                table: "Enfrentamiento",
                column: "SegundoJugadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Enfrentamiento_TorneoId",
                table: "Enfrentamiento",
                column: "TorneoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enfrentamiento");

            migrationBuilder.DropTable(
                name: "Jugadores");
        }
    }
}
