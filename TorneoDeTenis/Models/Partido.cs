using TorneoDeTenis.Services;

namespace TorneoDeTenis.Models
{
    public class Partido(Jugador primerJugador, Jugador segundoJugador, IEnfrentamientoStrategy enfrentamientoStrategy) : Enfrentamiento
    {
        public Jugador PrimerJugador { get; private set; } = primerJugador;
        public Jugador SegundoJugador { get; private set; } = segundoJugador;

        public IEnfrentamientoStrategy EnfrentamientoStrategy { get; private set; } = enfrentamientoStrategy;

        public void CalcularGanador()
        {
            Ganador = EnfrentamientoStrategy.CalcularGanador(primerJugador, segundoJugador);
        }
    }
}