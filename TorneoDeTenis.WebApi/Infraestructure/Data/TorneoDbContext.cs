using Microsoft.EntityFrameworkCore;
using TorneoDeTenis.WebApi.Models;

namespace TorneoDeTenis.WebApi.Infraestructure.Data
{
    public class TorneoDbContext(DbContextOptions<TorneoDbContext> options) : DbContext(options)
    {
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Torneo> Torneos { get; set; }
        public DbSet<Partido> Partidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones adicionales de entidades
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Partido>()
                .HasOne(p => p.PrimerJugador)
                .WithMany()
                .HasForeignKey("PrimerJugadorId")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Partido>()
                .HasOne(p => p.SegundoJugador)
                .WithMany()
                .HasForeignKey("SegundoJugadorId")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}