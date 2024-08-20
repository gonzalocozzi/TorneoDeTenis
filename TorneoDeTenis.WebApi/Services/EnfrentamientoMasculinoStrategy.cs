using TorneoDeTenis.WebApi.Models;

namespace TorneoDeTenis.WebApi.Services
{
    public class EnfrentamientoMasculinoStrategy : IEnfrentamientoStrategy
    {
        public Jugador CalcularGanador(Jugador jugador1, Jugador jugador2)
        {
            int puntaje1 = (jugador1.Habilidad + jugador1.Fuerza + jugador1.Velocidad) * jugador1.CalcularSuerte();
            int puntaje2 = (jugador2.Habilidad + jugador2.Fuerza + jugador2.Velocidad) * jugador2.CalcularSuerte();

            return puntaje1 > puntaje2 ? jugador1 : jugador2;
        }
    }
}