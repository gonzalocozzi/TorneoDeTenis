using TorneoDeTenis.WebApi.Builders;
using TorneoDeTenis.WebApi.Enums;
using TorneoDeTenis.WebApi.Exceptions;
using TorneoDeTenis.WebApi.Infraestructure.Data;
using TorneoDeTenis.WebApi.Models;
using TorneoDeTenis.WebApi.Services;

namespace TorneoDeTenis.Tests.Builders
{
    public class TorneoBuilderTests
    {
        private readonly Mock<IEnfrentamientoStrategy> _enfrentamientoStrategyMock;
        private readonly Mock<IJugadorRepository> _jugadorRepositoryMock;
        private readonly Mock<ITorneoRepository> _torneoRepositoryMock;
        private readonly TorneoBuilder _torneoBuilder;

        public TorneoBuilderTests()
        {
            _enfrentamientoStrategyMock = new Mock<IEnfrentamientoStrategy>();
            _jugadorRepositoryMock = new Mock<IJugadorRepository>();
            _torneoRepositoryMock = new Mock<ITorneoRepository>();
            _torneoBuilder = new TorneoBuilder(_enfrentamientoStrategyMock.Object, _jugadorRepositoryMock.Object, _torneoRepositoryMock.Object);
        }

        [Fact]
        public async Task CrearTorneo_CuandoNumeroDeJugadoresEsInvalido_DeberiaLanzarExcepcion()
        {
            // Arrange
            var jugadores = new List<Jugador>
            {
                new("Jugador 1", 70, 60, 80, 50),
                new("Jugador 2", 70, 60, 80, 50),
                new("Jugador 3", 70, 60, 80, 50) // Número no es potencia de 2
            };

            // Act & Assert
            await Assert.ThrowsAsync<NumeroDeJugadoresInvalidoException>(async () => await _torneoBuilder.CrearTorneo(jugadores, TipoTorneo.Femenino));
        }

        [Fact]
        public async Task CrearTorneo_CuandoNumeroDeJugadoresEsValido_DeberiaCrearRondasCorrectamente()
        {
            // Arrange
            var jugadores = new List<Jugador>
            {
                new("Jugador 1", 80, 70, 90, 50),
                new("Jugador 2", 70, 60, 80, 50),
                new("Jugador 3", 60, 50, 70, 40),
                new("Jugador 4", 90, 80, 100, 60)
            };

            _enfrentamientoStrategyMock.Setup(s => s.CalcularGanador(It.IsAny<Jugador>(), It.IsAny<Jugador>()))
                .Returns((Jugador j1, Jugador j2) => j1.Habilidad > j2.Habilidad ? j1 : j2);

            // Act
            var torneo = await _torneoBuilder.CrearTorneo(jugadores, TipoTorneo.Masculino);

            // Assert
            Assert.NotNull(torneo);
            Assert.Equal(2, torneo.Enfrentamientos.Count); // Dos rondas
            Assert.Equal(1, torneo.Enfrentamientos[0].NumeroDeRonda); // Primera ronda
            Assert.Equal(2, torneo.Enfrentamientos[1].NumeroDeRonda); // Segunda ronda (final)
            Assert.Equal("Jugador 4", torneo.Ganador?.Nombre);
        }

        [Fact]
        public async Task CrearTorneo_DeberiaActualizarGanadorEnRondaPrevia()
        {
            // Arrange
            var jugadores = new List<Jugador>
            {
                new("Jugador 1", 80, 70, 90, 50),
                new("Jugador 2", 70, 60, 80, 50),
                new("Jugador 3", 60, 50, 70, 40),
                new("Jugador 4", 90, 80, 100, 60)
            };

            _enfrentamientoStrategyMock.Setup(s => s.CalcularGanador(It.IsAny<Jugador>(), It.IsAny<Jugador>()))
                .Returns((Jugador j1, Jugador j2) => j1.Habilidad > j2.Habilidad ? j1 : j2);

            // Act
            var torneo = await _torneoBuilder.CrearTorneo(jugadores, TipoTorneo.Femenino);

            // Assert
            var primeraRonda = torneo.Enfrentamientos[0] as Torneo;
            var segundaRonda = torneo.Enfrentamientos[1] as Torneo;

            Assert.NotNull(primeraRonda?.Ganador);
            Assert.Equal("Jugador 4", primeraRonda?.Ganador?.Nombre);

            Assert.NotNull(segundaRonda?.Ganador);
            Assert.Equal("Jugador 4", segundaRonda?.Ganador?.Nombre);
        }

        [Fact]
        public async Task CrearTorneo_CuandoNumeroDeJugadoresEsPotenciaDeDos_DeberiaCalcularGanadorCorrectamente()
        {
            // Arrange
            var jugadores = new List<Jugador>
            {
                new("Jugador 1", 50, 60, 70, 80),
                new("Jugador 2", 40, 50, 60, 70),
                new("Jugador 3", 30, 40, 50, 60),
                new("Jugador 4", 20, 30, 40, 50),
                new("Jugador 5", 10, 20, 30, 40),
                new("Jugador 6", 60, 70, 80, 90),
                new("Jugador 7", 70, 80, 90, 100),
                new("Jugador 8", 80, 90, 100, 110)
            };

            _enfrentamientoStrategyMock.Setup(s => s.CalcularGanador(It.IsAny<Jugador>(), It.IsAny<Jugador>()))
                .Returns((Jugador j1, Jugador j2) => j1.Habilidad > j2.Habilidad ? j1 : j2);

            // Act
            var torneo = await _torneoBuilder.CrearTorneo(jugadores, TipoTorneo.Masculino);

            // Assert
            Assert.NotNull(torneo);
            Assert.Equal(3, torneo.Enfrentamientos.Count); // Tres rondas
            Assert.Equal("Jugador 8", torneo.Ganador?.Nombre);
        }
    }
}