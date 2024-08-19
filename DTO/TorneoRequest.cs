using TorneoDeTenis.Enums;

namespace TorneoDeTenis.DTO
{
    public class TorneoRequest
    {
        public TipoTorneo TipoTorneo { get; internal set; }
        public IEnumerable<JugadorRequest> Jugadores { get; set; }
    }
}