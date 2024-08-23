using TorneoDeTenis.WebApi.DTO;
using TorneoDeTenis.WebApi.Models;

namespace TorneoDeTenis.WebApi.Services
{
    public interface ITorneoService
    {
        /// <summary>
        /// Crea un torneo completo, con sus rondas y el correspondiente ganador, a partir de un DTO que indica el tipo de torneo y sus participantes
        /// </summary>
        /// <param name="torneoRequest">DTO que indica el tipo de torneo y sus participantes</param>
        /// <returns>Torneo completo, con sus rondas y el correspondiente ganador</returns>
        Task<Torneo> CrearTorneo(TorneoRequest torneoRequest);
    }
}