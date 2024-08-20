using TorneoDeTenis.WebApi.Models;

namespace TorneoDeTenis.WebApi.Services
{
    public class EnfrentamientoMasculinoStrategy(IRandomProvider randomProvider) : IEnfrentamientoStrategy
    {
        public IRandomProvider RandomProvider { get; } = randomProvider;

        public Jugador CalcularGanador(Jugador jugador1, Jugador jugador2)
        {
            var suerteJugador1 = RandomProvider.Next(0, 100);
            var suerteJugador2 = RandomProvider.Next(0, 100);

            int puntaje1 = (jugador1.Habilidad + jugador1.Fuerza + jugador1.Velocidad) * suerteJugador1;
            int puntaje2 = (jugador2.Habilidad + jugador2.Fuerza + jugador2.Velocidad) * suerteJugador2;

            return puntaje1 > puntaje2 ? jugador1 : jugador2;
        }
    }
}