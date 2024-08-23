using TorneoDeTenis.WebApi.Builders;
using TorneoDeTenis.WebApi.DTO;
using TorneoDeTenis.WebApi.Infraestructure.Data;
using TorneoDeTenis.WebApi.Models;

namespace TorneoDeTenis.WebApi.Services
{
    public class TorneoService(IEnfrentamientoStrategyFactory strategyFactory, IJugadorRepository jugadorRepository, ITorneoRepository torneoRepository) : ITorneoService
    {
        private readonly IJugadorRepository _jugadorRepository = jugadorRepository;
        private readonly ITorneoRepository _torneoRepository = torneoRepository;

        private readonly IEnfrentamientoStrategyFactory _strategyFactory = strategyFactory;

        public async Task<Torneo> CrearTorneo(TorneoRequest torneoRequest)
        {
            var strategy = _strategyFactory.CrearStrategy(torneoRequest.TipoTorneo);
            var jugadores = torneoRequest.Jugadores.Select(j => new Jugador(j.Nombre, j.Habilidad, j.Fuerza, j.Velocidad, j.TiempoReaccion)).ToList();
            var torneoBuilder = new TorneoBuilder(strategy, _jugadorRepository, _torneoRepository);
            return await torneoBuilder.CrearTorneo(jugadores, torneoRequest.TipoTorneo);
        }
    }
}