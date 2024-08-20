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
        public void CrearStrategy_CuandoEsTipoFemenino_DeberiaRetornarEnfrentamientoFemeninoStrategy()
        {
            var strategy = _factory.CrearStrategy(TipoTorneo.Femenino);

            Assert.IsType<EnfrentamientoFemeninoStrategy>(strategy);
        }

        [Fact]
        public void CrearStrategy_CuandoEsTipoMasculino_DeberiaRetornarEnfrentamientoMasculinoStrategy()
        {
            var strategy = _factory.CrearStrategy(TipoTorneo.Masculino);

            Assert.IsType<EnfrentamientoMasculinoStrategy>(strategy);
        }

        [Fact]
        public void CrearStrategy_CuandoEsTipoInexistente_DeberiaLanzarTipoDeTorneoInexistenteException()
        {
            Assert.Throws<TipoDeTorneoInexistenteException>(() => _factory.CrearStrategy((TipoTorneo)999));
        }

        [Fact]
        public void CrearStrategy_CuandoEsTipoMasculino_DeberiaPasarIRandomProviderAEnfrentamientoMasculinoStrategy()
        {
            var strategy = _factory.CrearStrategy(TipoTorneo.Masculino);

            var enfrentamientoMasculinoStrategy = Assert.IsType<EnfrentamientoMasculinoStrategy>(strategy);
            Assert.Equal(_randomProviderMock.Object, enfrentamientoMasculinoStrategy.RandomProvider);
        }

        [Fact]
        public void CrearStrategy_CuandoEsTipoFemenino_DeberiaPasarIRandomProviderAEnfrentamientoFemeninoStrategy()
        {
            var strategy = _factory.CrearStrategy(TipoTorneo.Femenino);

            var enfrentamientoFemeninoStrategy = Assert.IsType<EnfrentamientoFemeninoStrategy>(strategy);
            Assert.Equal(_randomProviderMock.Object, enfrentamientoFemeninoStrategy.RandomProvider);
        }
    }
}