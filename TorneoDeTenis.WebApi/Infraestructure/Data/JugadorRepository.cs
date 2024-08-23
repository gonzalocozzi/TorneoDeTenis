using Microsoft.EntityFrameworkCore;
using TorneoDeTenis.WebApi.Models;

namespace TorneoDeTenis.WebApi.Infraestructure.Data
{
    public class JugadorRepository(TorneoDbContext context) : IJugadorRepository
    {
        private readonly TorneoDbContext _context = context;

        public async Task<IEnumerable<Jugador>> GetAllAsync() => await _context.Jugadores.ToListAsync();

        public async Task<Jugador> GetByIdAsync(long id) => await _context.Jugadores.FindAsync(id);

        public async Task AddAsync(Jugador jugador) => await _context.Jugadores.AddAsync(jugador);

        public async Task UpdateAsync(Jugador jugador) => _context.Entry(jugador).State = EntityState.Modified;

        public async Task DeleteAsync(long id)
        {
            var jugador = await _context.Jugadores.FindAsync(id);
            if (jugador != null)
            {
                _context.Jugadores.Remove(jugador);
            }
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}