namespace TorneoDeTenis.Models
{
    public class Torneo : Enfrentamiento
    {
        public List<Enfrentamiento> Enfrentamientos { get; private set; } = [];

        public void AgregarEnfrentamiento(Enfrentamiento enfrentamiento) => Enfrentamientos.Add(enfrentamiento);

        public override void CalcularGanador()
        {
            var ganadores = Enfrentamientos.Select(sr => sr.Ganador).ToList();
            Ganador = ganadores.FirstOrDefault(); // Asume que hay un único ganador al final
        }
    }
}