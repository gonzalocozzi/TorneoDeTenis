using TorneoDeTenis.Services;

namespace TorneoDeTenis.Models
{
    public class Partido(Jugador jugador1, Jugador jugador2, IEnfrentamientoStrategy enfrentamientoStrategy) : Enfrentamiento
    {
        public Jugador Jugador1 { get; private set; } = jugador1;
        public Jugador Jugador2 { get; private set; } = jugador2;
        public IEnfrentamientoStrategy EnfrentamientoStrategy { get; private set; } = enfrentamientoStrategy;

        public override void CalcularGanador()
        {
            Ganador = EnfrentamientoStrategy.CalcularGanador(jugador1, jugador2);
        }
    }
}