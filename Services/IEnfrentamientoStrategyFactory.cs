using TorneoDeTenis.Enums;

namespace TorneoDeTenis.Services
{
    public interface IEnfrentamientoStrategyFactory
    {
        /// <summary>
        /// Interfaz que define la firma del contrato para crear una estrategia de enfrentamiento a partir del tipo de torneo
        /// </summary>
        /// <param name="tipoTorneo">Tipo de torneo a partir del que se define la estrategia de enfrentamientos</param>
        /// <returns>Estrategia de enfrentamiento entre jugadores correspondiente al tipo de torneo indicado</returns>
        IEnfrentamientoStrategy CrearStrategy(TipoTorneo tipoTorneo);
    }
}