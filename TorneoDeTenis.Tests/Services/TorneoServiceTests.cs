using TorneoDeTenis.WebApi.DTO;
using TorneoDeTenis.WebApi.Enums;
using TorneoDeTenis.WebApi.Exceptions;
using TorneoDeTenis.WebApi.Infraestructure.Data;
using TorneoDeTenis.WebApi.Services;

namespace TorneoDeTenis.Tests.Services
{
    public class TorneoServiceTests
    {
        private readonly Mock<IEnfrentamientoStrategyFactory> _strategyFactoryMock;
        private readonly Mock<IJugadorRepository> _jugadorRepositoryMock;
        private readonly Mock<ITorneoRepository> _torneoRepositoryMock;
        private readonly TorneoService _torneoService;

        public TorneoServiceTests()
        {
            _strategyFactoryMock = new Mock<IEnfrentamientoStrategyFactory>();
            _jugadorRepositoryMock = new Mock<IJugadorRepository>();
            _torneoRepositoryMock = new Mock<ITorneoRepository>();
            _torneoService = new TorneoService(_strategyFactoryMock.Object, _jugadorRepositoryMock.Object, _torneoRepositoryMock.Object);
        }

        [Fact]
        public async Task CrearTorneo_DeberiaLlamarAStrategyFactory_ConTipoTorneoCorrecto()
        {
            // Arrange
            var torneoRequest = new TorneoRequest
            {
                TipoTorneo = TipoTorneo.Masculino,
                Jugadores =
                [
                    new() { Nombre = "Jugador 1", Habilidad = 50, Fuerza = 60, Velocidad = 70, TiempoReaccion = 80 },
                    new() { Nombre = "Jugador 2", Habilidad = 50, Fuerza = 60, Velocidad = 70, TiempoReaccion = 80 }
                ]
            };
            var strategyMock = new Mock<IEnfrentamientoStrategy>();
            _strategyFactoryMock.Setup(factory => factory.CrearStrategy(TipoTorneo.Masculino))
                                .Returns(strategyMock.Object);

            // Act
            await _torneoService.CrearTorneo(torneoRequest);

            // Assert
            _strategyFactoryMock.Verify(factory => factory.CrearStrategy(TipoTorneo.Masculino), Times.Once);
        }

        [Fact]
        public async Task CrearTorneo_DeberiaDevolverTorneo_ConJugadoresEsperados()
        {
            // Arrange
            var torneoRequest = new TorneoRequest
            {
                TipoTorneo = TipoTorneo.Femenino,
                Jugadores =
                [
                    new() { Nombre = "Jugador 1", Habilidad = 50, Fuerza = 60, Velocidad = 70, TiempoReaccion = 80 },
                    new() { Nombre = "Jugador 2", Habilidad = 55, Fuerza = 65, Velocidad = 75, TiempoReaccion = 85 },
                    new() { Nombre = "Jugador 3", Habilidad = 60, Fuerza = 70, Velocidad = 80, TiempoReaccion = 90 },
                    new() { Nombre = "Jugador 4", Habilidad = 65, Fuerza = 75, Velocidad = 85, TiempoReaccion = 95 }
                ]
            };
            var strategyMock = new Mock<IEnfrentamientoStrategy>();
            _strategyFactoryMock.Setup(factory => factory.CrearStrategy(TipoTorneo.Femenino))
                                .Returns(strategyMock.Object);

            // Act
            var torneo = await _torneoService.CrearTorneo(torneoRequest);

            // Assert
            Assert.NotNull(torneo);
            Assert.True(torneo.Enfrentamientos.Count > 0);
        }

        [Fact]
        public async Task CrearTorneo_CuandoNoSeAsignanJugadores_DeberiaLanzarNumeroDeJugadoresInvalidoException()
        {
            // Arrange
            var torneoRequest = new TorneoRequest
            {
                TipoTorneo = TipoTorneo.Masculino,
                Jugadores = [] // Caso inválido: sin jugadores
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NumeroDeJugadoresInvalidoException>(() => _torneoService.CrearTorneo(torneoRequest));
            Assert.Equal("El número de jugadores debe ser una potencia de 2.", exception.Message);
        }

        [Fact]
        public async Task CrearTorneo_DeberiaCrearTorneo_ConNumeroCorrectoDeRondas()
        {
            // Arrange
            var torneoRequest = new TorneoRequest
            {
                TipoTorneo = TipoTorneo.Femenino,
                Jugadores =
                [
                    new() { Nombre = "Jugador 1", Habilidad = 50, Fuerza = 60, Velocidad = 70, TiempoReaccion = 80 },
                    new() { Nombre = "Jugador 2", Habilidad = 55, Fuerza = 65, Velocidad = 75, TiempoReaccion = 85 },
                    new() { Nombre = "Jugador 3", Habilidad = 60, Fuerza = 70, Velocidad = 80, TiempoReaccion = 90 },
                    new() { Nombre = "Jugador 4", Habilidad = 65, Fuerza = 75, Velocidad = 85, TiempoReaccion = 95 },
                    new() { Nombre = "Jugador 5", Habilidad = 50, Fuerza = 60, Velocidad = 70, TiempoReaccion = 80 },
                    new() { Nombre = "Jugador 6", Habilidad = 55, Fuerza = 65, Velocidad = 75, TiempoReaccion = 85 },
                    new() { Nombre = "Jugador 7", Habilidad = 60, Fuerza = 70, Velocidad = 80, TiempoReaccion = 90 },
                    new() { Nombre = "Jugador 8", Habilidad = 65, Fuerza = 75, Velocidad = 85, TiempoReaccion = 95 }
                ]
            };

            var strategyMock = new Mock<IEnfrentamientoStrategy>();
            _strategyFactoryMock.Setup(factory => factory.CrearStrategy(TipoTorneo.Femenino))
                                .Returns(strategyMock.Object);

            // Act
            var torneo = await _torneoService.CrearTorneo(torneoRequest);

            // Assert
            Assert.NotNull(torneo);
            Assert.Equal(3, torneo.Enfrentamientos.Count); // Se esperan 3 rondas para 8 jugadores
        }
    }
}