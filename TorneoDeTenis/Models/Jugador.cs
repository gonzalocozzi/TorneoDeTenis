using System.ComponentModel.DataAnnotations;

namespace TorneoDeTenis.Models
{
    public class Jugador(string nombre, int habilidad, int fuerza, int velocidad, int tiempoReaccion)
    {
        public string Nombre { get; set; } = nombre;

        [Range(0, 100, ErrorMessage = "La habilidad debe estar entre 0 y 100.")]
        public int Habilidad { get; set; } = habilidad;

        public int Fuerza { get; set; } = fuerza;
        public int Velocidad { get; set; } = velocidad;
        public int TiempoReaccion { get; set; } = tiempoReaccion;

        public int CalcularSuerte() => new Random().Next(0, 100);
    }
}