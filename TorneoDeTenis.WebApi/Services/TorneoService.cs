using TorneoDeTenis.WebApi.Builders;
using TorneoDeTenis.WebApi.DTO;
using TorneoDeTenis.WebApi.Models;

namespace TorneoDeTenis.WebApi.Services
{
    public class TorneoService(IEnfrentamientoStrategyFactory strategyFactory) : ITorneoService
    {
        private readonly IEnfrentamientoStrategyFactory _strategyFactory = strategyFactory;

        public Torneo CrearTorneo(TorneoRequest torneoRequest)
        {
            var strategy = _strategyFactory.CrearStrategy(torneoRequest.TipoTorneo);
            var jugadores = torneoRequest.Jugadores.Select(j => new Jugador(j.Nombre, j.Habilidad, j.Fuerza, j.Velocidad, j.TiempoReaccion)).ToList();
            var torneoBuilder = new TorneoBuilder(strategy);
            return torneoBuilder.CrearTorneo(jugadores);
        }
    }
}