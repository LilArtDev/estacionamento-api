using EstacionamentoAPI.Data;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoAPI.Repositories
{
    public class EstablishmentRepository : IEstablishmentRepository
    {
        private readonly AppDbContext _context;

        public EstablishmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Establishment>> GetAllAsync()
        {
            return await _context.Establishments.ToListAsync();
        }

        public async Task<Establishment> GetByIdAsync(int id)
        {
            return await _context.Establishments.FindAsync(id);
        }

        public async Task AddAsync(Establishment establishment)
        {
            await _context.Establishments.AddAsync(establishment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Establishment establishment)
        {
            _context.Establishments.Update(establishment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var establishment = await _context.Establishments.FindAsync(id);
            if (establishment != null)
            {
                _context.Establishments.Remove(establishment);
                await _context.SaveChangesAsync();
            }
        }
    }
}