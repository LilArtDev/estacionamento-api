using EstacionamentoAPI.Data;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoAPI.Repositories
{
    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private readonly AppDbContext _context;

        public EstabelecimentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estabelecimento>> GetAllAsync()
        {
            return await _context.Estabelecimentos.ToListAsync();
        }

        public async Task<Estabelecimento> GetByIdAsync(int id)
        {
            return await _context.Estabelecimentos.FindAsync(id);
        }

        public async Task AddAsync(Estabelecimento estabelecimento)
        {
            await _context.Estabelecimentos.AddAsync(estabelecimento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Estabelecimento estabelecimento)
        {
            _context.Estabelecimentos.Update(estabelecimento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var estabelecimento = await _context.Estabelecimentos.FindAsync(id);
            if (estabelecimento != null)
            {
                _context.Estabelecimentos.Remove(estabelecimento);
                await _context.SaveChangesAsync();
            }
        }
    }
}