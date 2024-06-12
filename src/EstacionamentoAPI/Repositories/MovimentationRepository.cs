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

        public async Task<IEnumerable<Movimentations>> GetAllAsync()
        {
            return await _context.Movimentations.ToListAsync();
        }
        public async Task<IEnumerable<Movimentations>> GetAllAsync(int id)
        {
            return await _context.Movimentations.ToListAsync();
        }
        public async Task<IEnumerable<Movimentations>> GetByVehicleIdAsync(int vehicleId)
        {
            return await _context.Movimentations.Where(Movimentations => Movimentations.VehicleId.Equals(vehicleId)).ToListAsync();
        }
        public async Task<IEnumerable<Movimentations>> GetByEstablishmentIdAsync(int movimentationId)
        {
            return await _context.Movimentations.Where(Movimentations => Movimentations.EstablishmentId.Equals(movimentationId)).ToListAsync();
        }

        public async Task<Movimentations> GetByIdAsync(int id)
        {
            return await _context.Movimentations.FindAsync(id);
        }

        public async Task AddAsync(Movimentations Movimentations)
        {
            await _context.Movimentations.AddAsync(Movimentations);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movimentations Movimentations)
        {
            _context.Movimentations.Update(Movimentations);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Movimentations = await _context.Movimentations.FindAsync(id);
            if (Movimentations != null)
            {
                _context.Movimentations.Remove(Movimentations);
                await _context.SaveChangesAsync();
            }
        }
    }
}