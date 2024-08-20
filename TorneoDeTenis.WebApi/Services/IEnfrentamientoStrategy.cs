using TorneoDeTenis.WebApi.Models;

namespace TorneoDeTenis.WebApi.Services
{
    /// <summary>
    /// Interfaz que define las estrategias de enfrentamiento entre jugadores para cada tipo de torneo
    /// </summary>
    public interface IEnfrentamientoStrategy
    {
        /// <summary>
        /// Cálculo del ganador en un enfrentamiento entre dos jugadores
        /// </summary>
        /// <param name="jugador1">Primer jugador del enfrentamiento</param>
        /// <param name="jugador2">Segundo jugador del enfrentamiento</param>
        /// <returns>Jugador ganador resultante del enfrentamiento</returns>
        Jugador CalcularGanador(Jugador jugador1, Jugador jugador2);
    }
}