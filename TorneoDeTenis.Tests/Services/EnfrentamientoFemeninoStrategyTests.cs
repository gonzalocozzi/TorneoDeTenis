using TorneoDeTenis.WebApi.Models;
using TorneoDeTenis.WebApi.Services;

namespace TorneoDeTenis.Tests.Services
{
    public class EnfrentamientoFemeninoStrategyTests
    {
        private readonly Mock<IRandomProvider> _randomProviderMock;
        private readonly EnfrentamientoFemeninoStrategy _strategy;

        public EnfrentamientoFemeninoStrategyTests()
        {
            _randomProviderMock = new Mock<IRandomProvider>();
            _strategy = new EnfrentamientoFemeninoStrategy(_randomProviderMock.Object);
        }

        [Fact]
        public void CalcularGanador_CuandoJugador1TieneMayorPuntaje_DeberiaDevolverJugador1()
        {
            // Arrange
            var jugador1 = new Jugador("Jugador 1", 80, 70, 90, 50);
            var jugador2 = new Jugador("Jugador 2", 60, 50, 70, 40);

            _randomProviderMock.Setup(r => r.Next(0, 100)).Returns(50);

            // Act
            var ganador = _strategy.CalcularGanador(jugador1, jugador2);

            // Assert
            Assert.Equal(jugador1, ganador);
        }

        [Fact]
        public void CalcularGanador_CuandoJugador2TieneMayorPuntaje_DeberiaDevolverJugador2()
        {
            // Arrange
            var jugador1 = new Jugador("Jugador 1", 60, 50, 70, 40);
            var jugador2 = new Jugador("Jugador 2", 80, 70, 90, 50);

            _randomProviderMock.Setup(r => r.Next(0, 100)).Returns(50);

            // Act
            var ganador = _strategy.CalcularGanador(jugador1, jugador2);

            // Assert
            Assert.Equal(jugador2, ganador);
        }

        [Fact]
        public void CalcularGanador_CuandoJugadoresTienenIgualPuntaje_DeberiaDevolverJugador2()
        {
            // Arrange
            var jugador1 = new Jugador("Jugador 1", 70, 60, 80, 50);
            var jugador2 = new Jugador("Jugador 2", 70, 60, 80, 50);

            _randomProviderMock.SetupSequence(r => r.Next(0, 100))
                .Returns(50)  // Suerte de jugador 1
                .Returns(50); // Suerte de jugador 2

            // Act
            var ganador = _strategy.CalcularGanador(jugador1, jugador2);

            // Assert
            Assert.Equal(jugador2, ganador);
        }

        [Fact]
        public void CalcularGanador_DeberiaLlamarRandomProviderParaAmbosJugadores()
        {
            // Arrange
            var jugador1 = new Jugador("Jugador 1", 70, 60, 80, 50);
            var jugador2 = new Jugador("Jugador 2", 70, 60, 80, 50);

            _randomProviderMock.SetupSequence(r => r.Next(0, 100))
                .Returns(50)  // Suerte de jugador 1
                .Returns(50); // Suerte de jugador 2

            // Act
            _strategy.CalcularGanador(jugador1, jugador2);

            // Assert
            _randomProviderMock.Verify(r => r.Next(0, 100), Times.Exactly(2));
        }
    }
}