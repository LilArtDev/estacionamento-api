using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories.Interfaces;
using EstacionamentoAPI.Services.Interfaces;

namespace EstacionamentoAPI.Services
{
    public class EstablishmentService : IEstablishmentService
    {
        private readonly IEstablishmentRepository _repository;

        public EstablishmentService(IEstablishmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Establishment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Establishment> GetByIdAsync(int id)
        {
            var establishment = await _repository.GetByIdAsync(id);

            if (establishment == null) throw new KeyNotFoundException("Establishment não encontrado");

            return establishment;
        }

        public async Task AddAsync(Establishment establishment)
        {
            await _repository.AddAsync(establishment);
        }

        public async Task UpdateAsync(int id, Establishment establishmentAtualizado)
        {
            var establishment = await _repository.GetByIdAsync(id);

            if (establishment == null) throw new KeyNotFoundException("Establishment não encontrado");

            if (establishment.Equals(establishmentAtualizado)) throw new BadHttpRequestException("Nenhuma alteração realizada");

            await _repository.UpdateAsync(establishmentAtualizado);
        }

        public async Task DeleteAsync(int id)
        {
            var establishment = await _repository.GetByIdAsync(id);

            if (establishment == null) throw new KeyNotFoundException("Establishment não encontrado");

            await _repository.DeleteAsync(id);
        }


        public async Task<bool> CheckEstablishmentExistsByIdAsync(int id)
        {
            var establishment = await _repository.GetByIdAsync(id);

            return establishment != null;
        }
    }
}