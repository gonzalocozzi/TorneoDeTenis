using TorneoDeTenis.WebApi.Enums;
using TorneoDeTenis.WebApi.Exceptions;

namespace TorneoDeTenis.WebApi.Services
{
    public class EnfrentamientoStrategyFactory(IRandomProvider randomProvider) : IEnfrentamientoStrategyFactory
    {
        private readonly IRandomProvider _randomProvider = randomProvider;

        public IEnfrentamientoStrategy CrearStrategy(TipoTorneo tipoTorneo) => tipoTorneo switch
        {
            TipoTorneo.Femenino => new EnfrentamientoFemeninoStrategy(_randomProvider),
            TipoTorneo.Masculino => new EnfrentamientoMasculinoStrategy(_randomProvider),
            _ => throw new TipoDeTorneoInexistenteException("Tipo de torneo inexistente.")
        };
    }
}