using EstacionamentoAPI.DTOs.Responses;
using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Services.Interfaces
{
    public interface IEstablishmentService
    {
        Task<IEnumerable<Establishment>> GetAllAsync();
        Task<Establishment> GetByIdAsync(int establishmentId);
        Task AddAsync(Establishment establishment);
        Task UpdateAsync(int establishmentId, Establishment establishment);
        Task DeleteAsync(int establishmentId);

        Task<bool> CheckEstablishmentExistsByIdAsync(int establishmentId);
        Task<EstablishmentStatus> GetEstablishmentStatusByIdAsync(int establishmentId);
    }
}