namespace TorneoDeTenis.WebApi.Models
{
    public class Torneo : Enfrentamiento
    {
        public int NumeroDeRonda { get; internal set; }
        public List<Enfrentamiento> Enfrentamientos { get; private set; } = [];

        public void AgregarEnfrentamiento(Enfrentamiento enfrentamiento) => Enfrentamientos.Add(enfrentamiento);
    }
}