using TorneoDeTenis.Exceptions;
using TorneoDeTenis.Models;
using TorneoDeTenis.Services;

namespace TorneoDeTenis.Builders
{
    public class TorneoBuilder(IEnfrentamientoStrategy enfrentamientoStrategy)
    {
        private readonly IEnfrentamientoStrategy _enfrentamientoStrategy = enfrentamientoStrategy;

        public Torneo CrearTorneo(List<Jugador> jugadores)
        {
            if (jugadores == null || jugadores.Count == 0 || (jugadores.Count & (jugadores.Count - 1)) != 0)
            {
                throw new NumeroDeJugadoresInvalidoException("El número de jugadores debe ser una potencia de 2.");
            }

            var jugadoresActuales = new List<Jugador>(jugadores);
            var torneo = new Torneo();

            while (jugadoresActuales.Count > 1)
            {
                var enfrentamiento = new Torneo();

                for (int i = 0; i < jugadoresActuales.Count; i += 2)
                {
                    var partido = new Partido(jugadoresActuales[i], jugadoresActuales[i + 1], _enfrentamientoStrategy);
                    partido.CalcularGanador();
                    enfrentamiento.AgregarEnfrentamiento(partido);
                }

                jugadoresActuales = enfrentamiento.Enfrentamientos.Select(sr => sr.Ganador).ToList();
                torneo.AgregarEnfrentamiento(enfrentamiento);
            }

            return torneo;
        }
    }
}