using System.ComponentModel.DataAnnotations.Schema;
using TorneoDeTenis.WebApi.Services;

namespace TorneoDeTenis.WebApi.Models
{
    public class Partido : Enfrentamiento
    {
        public Jugador PrimerJugador { get; private set; }
        public Jugador SegundoJugador { get; private set; }

        [NotMapped]
        public IEnfrentamientoStrategy EnfrentamientoStrategy { get; private set; }

        public Partido(Jugador primerJugador, Jugador segundoJugador, int numeroDeRonda, IEnfrentamientoStrategy enfrentamientoStrategy)
        {
            PrimerJugador = primerJugador;
            SegundoJugador = segundoJugador;
            NumeroDeRonda = numeroDeRonda;
            EnfrentamientoStrategy = enfrentamientoStrategy;
            Fecha = DateTime.UtcNow;
        }

        // Constructor sin parámetros para EF Core
        protected Partido()
        {
        }

        public void CalcularGanador() => Ganador = EnfrentamientoStrategy.CalcularGanador(PrimerJugador, SegundoJugador);
    }

}