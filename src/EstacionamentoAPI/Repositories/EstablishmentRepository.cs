using EstacionamentoAPI.Data;
using EstacionamentoAPI.DTOs.Responses;
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

        public async Task<Establishment> GetByIdAsync(int establishmentId)
        {
            return await _context.Establishments.FindAsync(establishmentId);
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

        public async Task DeleteAsync(int establishmentId)
        {
            var establishment = await _context.Establishments.FindAsync(establishmentId);
            if (establishment != null)
            {
                _context.Establishments.Remove(establishment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<EstablishmentStatus> GetEstablishmentStatusByIdAsync(int establishmentId)
        {
            var query = from establishment in _context.Establishments.Where(establishment => establishment.Id.Equals(establishmentId))
                        let occupiedMotorcycleSpaces = _context.Movimentations.Count(movimentation => movimentation.CheckoutAt == null)
                        let occupiedCarSpaces = _context.Movimentations.Count(movimentation => movimentation.CheckoutAt == null)
                        select new EstablishmentStatus
                        {
                            EstablishmentId = establishment.Id,
                            TotalCarSpaces = establishment.CarSpaces,
                            TotalMotorcycleSpaces = establishment.MotorcycleSpaces,
                            OccupiedCarSpaces = occupiedCarSpaces,
                            OccupiedMotorcycleSpaces = occupiedMotorcycleSpaces,
                            AvailableCarSpaces = establishment.CarSpaces - occupiedCarSpaces,
                            AvailableMotorcycleSpaces = establishment.MotorcycleSpaces - occupiedMotorcycleSpaces,

                        };

            return await query.FirstAsync();
        }

    }
}