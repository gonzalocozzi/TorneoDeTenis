namespace TorneoDeTenis.WebApi.Models
{
    public abstract class Enfrentamiento
    {
        public int NumeroDeRonda { get; internal set; }

        public Jugador Ganador { get; set; }
    }
}