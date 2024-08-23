using TorneoDeTenis.WebApi.Enums;
using TorneoDeTenis.WebApi.Exceptions;
using TorneoDeTenis.WebApi.Infraestructure.Data;
using TorneoDeTenis.WebApi.Models;
using TorneoDeTenis.WebApi.Services;

namespace TorneoDeTenis.WebApi.Builders
{
    public class TorneoBuilder(IEnfrentamientoStrategy enfrentamientoStrategy, IJugadorRepository jugadorRepository, ITorneoRepository torneoRepository)
    {
        private readonly IEnfrentamientoStrategy _enfrentamientoStrategy = enfrentamientoStrategy;
        private readonly IJugadorRepository _jugadorRepository = jugadorRepository;
        private readonly ITorneoRepository _torneoRepository = torneoRepository;

        public async Task<Torneo> CrearTorneo(List<Jugador> jugadores, TipoTorneo tipoTorneo)
        {
            ValidarJugadores(jugadores);

            jugadores = MezclarJugadores(jugadores);
            await GuardarJugadoresAsync(jugadores);

            var torneo = await CrearRondasAsync(jugadores, tipoTorneo);

            return torneo;
        }

        private static void ValidarJugadores(List<Jugador> jugadores)
        {
            if (jugadores == null || jugadores.Count == 0 || (jugadores.Count & (jugadores.Count - 1)) != 0)
            {
                throw new NumeroDeJugadoresInvalidoException("El número de jugadores debe ser una potencia de 2.");
            }
        }

        private static List<Jugador> MezclarJugadores(List<Jugador> jugadores) => [.. jugadores.OrderBy(j => Guid.NewGuid())];

        private async Task GuardarJugadoresAsync(List<Jugador> jugadores)
        {
            foreach (var jugador in jugadores)
            {
                await _jugadorRepository.AddAsync(jugador);
            }
            await _jugadorRepository.SaveChangesAsync();
        }

        private async Task<Torneo> CrearRondasAsync(List<Jugador> jugadores, TipoTorneo tipoTorneo)
        {
            var torneo = new Torneo() { TipoTorneo = tipoTorneo };
            var jugadoresActuales = new List<Jugador>(jugadores);
            int numeroDeRonda = 1;
            Torneo? rondaPrevia = null;

            while (jugadoresActuales.Count > 1)
            {
                var rondaActual = CrearRonda(jugadoresActuales, numeroDeRonda, tipoTorneo);
                jugadoresActuales = rondaActual.Enfrentamientos.Select(sr => sr.Ganador).ToList();

                if (rondaPrevia != null)
                {
                    rondaPrevia.Ganador = jugadoresActuales.Count == 1 ? jugadoresActuales.Single() : null;
                    await _torneoRepository.UpdateAsync(rondaPrevia);
                }

                torneo.AgregarEnfrentamiento(rondaActual);
                await _torneoRepository.AddAsync(rondaActual);
                await _torneoRepository.SaveChangesAsync();

                rondaPrevia = rondaActual;
                numeroDeRonda++;
            }

            torneo.Ganador = jugadoresActuales.Single();
            if (rondaPrevia != null)
            {
                rondaPrevia.Ganador = torneo.Ganador;
            }

            return torneo;
        }

        private Torneo CrearRonda(List<Jugador> jugadoresActuales, int numeroDeRonda, TipoTorneo tipoTorneo)
        {
            var rondaActual = new Torneo { NumeroDeRonda = numeroDeRonda, TipoTorneo = tipoTorneo };

            for (int i = 0; i < jugadoresActuales.Count; i += 2)
            {
                var partido = new Partido(jugadoresActuales[i], jugadoresActuales[i + 1], numeroDeRonda, _enfrentamientoStrategy);
                partido.CalcularGanador();
                rondaActual.AgregarEnfrentamiento(partido);
            }

            return rondaActual;
        }
    }
}