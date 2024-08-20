using TorneoDeTenis.WebApi.Enums;

namespace TorneoDeTenis.WebApi.DTO
{
    public class TorneoRequest
    {
        public TipoTorneo TipoTorneo { get; set; }
        public IEnumerable<JugadorRequest> Jugadores { get; set; }
    }
}