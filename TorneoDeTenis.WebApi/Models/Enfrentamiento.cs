using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TorneoDeTenis.WebApi.Enums;

namespace TorneoDeTenis.WebApi.Models
{
    public abstract class Enfrentamiento
    {
        [JsonIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime? Fecha { get; internal set; }
        public int NumeroDeRonda { get; internal set; }
        public TipoTorneo TipoTorneo { get; set; }
        public Jugador? Ganador { get; set; }
    }
}