using TorneoDeTenis.Services;

namespace TorneoDeTenis.Models
{
    public class Partido(Jugador jugador1, Jugador jugador2, IEnfrentamientoStrategy enfrentamientoStrategy) : Ronda
    {
        public Jugador Jugador1 { get; private set; } = jugador1;
        public Jugador Jugador2 { get; private set; } = jugador2;
        public IEnfrentamientoStrategy EnfrentamientoStrategy { get; private set; } = enfrentamientoStrategy;
        public Jugador Ganador { get; private set; }

        public override Jugador ObtenerGanador() => EnfrentamientoStrategy.CalcularGanador(jugador1, jugador1);
    }
}