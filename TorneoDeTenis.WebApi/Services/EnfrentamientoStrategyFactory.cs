using TorneoDeTenis.WebApi.Enums;
using TorneoDeTenis.WebApi.Exceptions;

namespace TorneoDeTenis.WebApi.Services
{
    public class EnfrentamientoStrategyFactory : IEnfrentamientoStrategyFactory
    {
        public IEnfrentamientoStrategy CrearStrategy(TipoTorneo tipoTorneo) => tipoTorneo switch
        {
            TipoTorneo.Femenino => new EnfrentamientoFemeninoStrategy(),
            TipoTorneo.Masculino => new EnfrentamientoMasculinoStrategy(),
            _ => throw new TipoDeTorneoInexistenteException("Tipo de torneo inexistente.")
        };
    }
}