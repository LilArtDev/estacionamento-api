using EstacionamentoAPI.Data;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoAPI.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly AppDbContext _context;

        public VeiculoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Veiculo>> GetAllAsync()
        {
            return await _context.Veiculos.ToListAsync();
        }

        public async Task<Veiculo> GetByIdAsync(int id)
        {
            return await _context.Veiculos.FindAsync(id);
        }

        public async Task AddAsync(Veiculo veiculo)
        {
            await _context.Veiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo != null)
            {
                _context.Veiculos.Remove(veiculo);
                await _context.SaveChangesAsync();
            }
        }
    }
}