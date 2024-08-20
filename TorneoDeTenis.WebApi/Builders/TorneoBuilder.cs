using TorneoDeTenis.WebApi.Exceptions;
using TorneoDeTenis.WebApi.Models;
using TorneoDeTenis.WebApi.Services;

namespace TorneoDeTenis.WebApi.Builders
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

            var torneo = new Torneo();
            var jugadoresActuales = new List<Jugador>(jugadores);
            int numeroDeRonda = 1;
            Torneo? rondaPrevia = null;

            while (jugadoresActuales.Count > 1)
            {
                var rondaActual = new Torneo() { NumeroDeRonda = numeroDeRonda };

                for (int i = 0; i < jugadoresActuales.Count; i += 2)
                {
                    var partido = new Partido(jugadoresActuales[i], jugadoresActuales[i + 1], _enfrentamientoStrategy);
                    partido.CalcularGanador();
                    rondaActual.AgregarEnfrentamiento(partido);
                }

                jugadoresActuales = rondaActual.Enfrentamientos.Select(sr => sr.Ganador).ToList();

                if (rondaPrevia != null)
                {
                    rondaPrevia.Ganador = jugadoresActuales.Count == 1 ? jugadoresActuales.Single() : null;
                }

                torneo.AgregarEnfrentamiento(rondaActual);
                rondaPrevia = rondaActual;
                numeroDeRonda++;
            }

            var ganadorDelTorneo = jugadoresActuales.Single();
            torneo.Ganador = ganadorDelTorneo;

            if (rondaPrevia != null)
            {
                rondaPrevia.Ganador = ganadorDelTorneo;
            }

            return torneo;
        }
    }
}