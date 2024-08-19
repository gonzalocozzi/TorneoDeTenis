namespace TorneoDeTenis.Models
{
    public abstract class Enfrentamiento
    {
        public Jugador Ganador { get; internal set; }
        public abstract void CalcularGanador();
    }
}