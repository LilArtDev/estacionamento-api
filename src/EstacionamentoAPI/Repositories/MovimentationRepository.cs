using EstacionamentoAPI.Data;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoAPI.Repositories
{
    public class MovimentationRepository : IMovimentationRepository
    {
        private readonly AppDbContext _context;

        public MovimentationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movimentation>> GetAllAsync()
        {
            return await _context.Movimentation.ToListAsync();
        }
        public async Task<IEnumerable<Movimentation>> GetAllAsync(int id)
        {
            return await _context.Movimentation.ToListAsync();
        }
        public async Task<IEnumerable<Movimentation>> GetByVehicleIdAsync(int vehicleId)
        {
            return await _context.Movimentation.Where(movimentation => movimentation.VehicleId.Equals(vehicleId)).ToListAsync();
        }
        public async Task<IEnumerable<Movimentation>> GetByEstablishmentIdAsync(int movimentationId)
        {
            return await _context.Movimentation.Where(movimentation => movimentation.EstablishmentId.Equals(movimentationId)).ToListAsync();
        }

        public async Task<Movimentation> GetByIdAsync(int id)
        {
            return await _context.Movimentation.FindAsync(id);
        }

        public async Task AddAsync(Movimentation movimentation)
        {
            await _context.Movimentation.AddAsync(movimentation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movimentation movimentation)
        {
            _context.Movimentation.Update(movimentation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movimentation = await _context.Movimentation.FindAsync(id);
            if (movimentation != null)
            {
                _context.Movimentation.Remove(movimentation);
                await _context.SaveChangesAsync();
            }
        }
    }
}