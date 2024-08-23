using Microsoft.EntityFrameworkCore;
using TorneoDeTenis.WebApi.Models;

namespace TorneoDeTenis.WebApi.Infraestructure.Data
{
    public class TorneoRepository(TorneoDbContext context) : ITorneoRepository
    {
        private readonly TorneoDbContext _context = context;

        public async Task<IEnumerable<Torneo>> GetAllAsync() => await _context.Torneos.ToListAsync();

        public async Task<Torneo> GetByIdAsync(long id) => await _context.Torneos.FindAsync(id);

        public async Task AddAsync(Torneo torneo) => await _context.Torneos.AddAsync(torneo);

        public async Task UpdateAsync(Torneo torneo) => _context.Entry(torneo).State = EntityState.Modified;

        public async Task DeleteAsync(long id)
        {
            var torneo = await _context.Torneos.FindAsync(id);
            if (torneo != null)
            {
                _context.Torneos.Remove(torneo);
            }
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
