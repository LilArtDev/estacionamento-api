using EstacionamentoAPI.Data;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoAPI.Repositories
{
    public class RegistroMovimentacaoRepository : IRegistroMovimentacaoRepository
    {
        private readonly AppDbContext _context;

        public RegistroMovimentacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegistroMovimentacao>> GetAllAsync()
        {
            return await _context.RegistroMovimentacao.ToListAsync();
        }
        public async Task<IEnumerable<RegistroMovimentacao>> GetAllAsync(int id)
        {
            return await _context.RegistroMovimentacao.ToListAsync();
        }
        public async Task<IEnumerable<RegistroMovimentacao>> GetByVeiculoIdAsync(int veiculoId)
        {
            return await _context.RegistroMovimentacao.Where(registroMovimentacao => registroMovimentacao.VeiculoId.Equals(veiculoId)).ToListAsync();
        }
        public async Task<IEnumerable<RegistroMovimentacao>> GetByEstabelecimentoIdAsync(int registroMovimentacaoId)
        {
            return await _context.RegistroMovimentacao.Where(registroMovimentacao => registroMovimentacao.EstabelecimentoId.Equals(registroMovimentacaoId)).ToListAsync();
        }

        public async Task<RegistroMovimentacao> GetByIdAsync(int id)
        {
            return await _context.RegistroMovimentacao.FindAsync(id);
        }

        public async Task AddAsync(RegistroMovimentacao registroMovimentacao)
        {
            await _context.RegistroMovimentacao.AddAsync(registroMovimentacao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RegistroMovimentacao registroMovimentacao)
        {
            _context.RegistroMovimentacao.Update(registroMovimentacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var registroMovimentacao = await _context.RegistroMovimentacao.FindAsync(id);
            if (registroMovimentacao != null)
            {
                _context.RegistroMovimentacao.Remove(registroMovimentacao);
                await _context.SaveChangesAsync();
            }
        }
    }
}