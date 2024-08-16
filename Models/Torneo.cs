namespace TorneoDeTenis.Models
{
    public class Torneo : Ronda
    {
        public List<Ronda> Rondas { get; private set; } = [];
        public Jugador Ganador { get; private set; }

        public void AgregarRonda(Ronda ronda) => Rondas.Add(ronda);

        public override Jugador ObtenerGanador()
        {
            throw new NotImplementedException();
        }
    }
}