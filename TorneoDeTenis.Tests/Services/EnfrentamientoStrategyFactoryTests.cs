using TorneoDeTenis.WebApi.Enums;
using TorneoDeTenis.WebApi.Exceptions;
using TorneoDeTenis.WebApi.Services;

namespace TorneoDeTenis.Tests.Services
{
    public class EnfrentamientoStrategyFactoryTests
    {
        private readonly Mock<IRandomProvider> _randomProviderMock;
        private readonly EnfrentamientoStrategyFactory _factory;

        public EnfrentamientoStrategyFactoryTests()
        {
            _randomProviderMock = new Mock<IRandomProvider>();
            _factory = new EnfrentamientoStrategyFactory(_randomProviderMock.Object);
        }

        [Fact]
        public void CrearStrategy_CuandoEsTipoFemenino_DeberiaDevolverEnfrentamientoFemeninoStrategy()
        {
            // Act
            var strategy = _factory.CrearStrategy(TipoTorneo.Femenino);

            // Assert
            Assert.IsType<EnfrentamientoFemeninoStrategy>(strategy);
        }

        [Fact]
        public void CrearStrategy_CuandoEsTipoMasculino_DeberiaDevolverEnfrentamientoMasculinoStrategy()
        {
            // Act
            var strategy = _factory.CrearStrategy(TipoTorneo.Masculino);

            // Assert
            Assert.IsType<EnfrentamientoMasculinoStrategy>(strategy);
        }

        [Fact]
        public void CrearStrategy_CuandoEsTipoInexistente_DeberiaLanzarTipoDeTorneoInexistenteException()
        {
            // Act & Assert
            Assert.Throws<TipoDeTorneoInexistenteException>(() => _factory.CrearStrategy((TipoTorneo)999));
        }

        [Fact]
        public void CrearStrategy_CuandoEsTipoMasculino_DeberiaPasarIRandomProviderAEnfrentamientoMasculinoStrategy()
        {
            // Act
            var strategy = _factory.CrearStrategy(TipoTorneo.Masculino);

            // Assert
            var enfrentamientoMasculinoStrategy = Assert.IsType<EnfrentamientoMasculinoStrategy>(strategy);
            Assert.Equal(_randomProviderMock.Object, enfrentamientoMasculinoStrategy.RandomProvider);
        }

        [Fact]
        public void CrearStrategy_CuandoEsTipoFemenino_DeberiaPasarIRandomProviderAEnfrentamientoFemeninoStrategy()
        {
            // Act
            var strategy = _factory.CrearStrategy(TipoTorneo.Femenino);

            // Assert
            var enfrentamientoFemeninoStrategy = Assert.IsType<EnfrentamientoFemeninoStrategy>(strategy);
            Assert.Equal(_randomProviderMock.Object, enfrentamientoFemeninoStrategy.RandomProvider);
        }
    }
}