using TorneoDeTenis.DTO;
using TorneoDeTenis.Models;

namespace TorneoDeTenis.Services
{
    public interface ITorneoService
    {
        /// <summary>
        /// Crea un torneo completo, con sus rondas y el correspondiente ganador, a partir de un DTO que indica el tipo de torneo y sus participantes
        /// </summary>
        /// <param name="torneoRequest">DTO que indica el tipo de torneo y sus participantes</param>
        /// <returns>Torneo completo, con sus rondas y el correspondiente ganador</returns>
        Torneo CrearTorneo(TorneoRequest torneoRequest);
    }
}