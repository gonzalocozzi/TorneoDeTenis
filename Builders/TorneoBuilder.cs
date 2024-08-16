using TorneoDeTenis.Models;
using TorneoDeTenis.Services;

namespace TorneoDeTenis.Builders
{
    public class TorneoBuilder(IEnfrentamientoStrategy enfrentamientoStrategy)
    {
        private readonly IEnfrentamientoStrategy _enfrentamientoStrategy = enfrentamientoStrategy;

        public Torneo JugarTorneo(List<Jugador> jugadores)
        {
            throw new NotImplementedException();
        }
    }
}