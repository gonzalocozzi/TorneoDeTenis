using TorneoDeTenis.Models;

namespace TorneoDeTenis.Services
{
    public class EnfrentamientoFemeninoStrategy : IEnfrentamientoStrategy
    {
        public Jugador CalcularGanador(Jugador jugador1, Jugador jugador2)
        {
            int puntaje1 = (jugador1.Habilidad + jugador1.TiempoReaccion) * jugador1.CalcularSuerte();
            int puntaje2 = (jugador2.Habilidad + jugador2.TiempoReaccion) * jugador2.CalcularSuerte();

            return puntaje1 > puntaje2 ? jugador1 : jugador2;
        }
    }
}