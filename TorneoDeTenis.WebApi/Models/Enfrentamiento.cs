namespace TorneoDeTenis.WebApi.Models
{
    public abstract class Enfrentamiento
    {
        public Jugador Ganador { get; internal set; }
    }
}