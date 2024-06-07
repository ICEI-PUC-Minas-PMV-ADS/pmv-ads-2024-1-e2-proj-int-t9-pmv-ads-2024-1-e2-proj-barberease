using BarberEaseApi.Database;
using BarberEaseApi.Entities;
using BarberEaseApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberEaseApi.Repositories
{
    public class EstablishmentServiceRepository : BaseRepository<EstablishmentServiceEntity>, IEstablishmentServiceRepository
    {
        private readonly DbSet<EstablishmentServiceEntity> _dataset;

        public EstablishmentServiceRepository(AppDbContext context) : base(context)
        {
            _dataset = context.Set<EstablishmentServiceEntity>();
        }

        public async Task<bool> ExistsByNameAndEstablishment(string name, Guid establishmentId)
        {
            return await _dataset.AnyAsync((establishmentService) =>
                establishmentService.Name.ToLower() == name.ToLower() &&
                establishmentService.EstablishmentId == establishmentId);
        }
    }
}
