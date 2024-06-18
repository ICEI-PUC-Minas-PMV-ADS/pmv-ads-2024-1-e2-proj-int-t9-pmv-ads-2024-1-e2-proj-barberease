using BarberEaseApi.Database;
using BarberEaseApi.Entities;
using BarberEaseApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberEaseApi.Repositories
{
    public class EstablishmentPeriodRepository : BaseRepository<EstablishmentPeriodEntity>, IEstablishmentPeriodRepository
    {
        private readonly DbSet<EstablishmentPeriodEntity> _dataset;

        public EstablishmentPeriodRepository(AppDbContext context) : base(context)
        {
            _dataset = context.Set<EstablishmentPeriodEntity>();
        }

        public async Task<IEnumerable<EstablishmentPeriodEntity>> FindAllByEstablishment(Guid establishmentId)
        {
            return await _dataset
                .Where((establishmentPeriod) => establishmentPeriod.EstablishmentId == establishmentId)
                .OrderBy((establishmentPeriod) => establishmentPeriod.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> ExistsByDayOfWeekAndEstablishment(string dayOfWeek, Guid establishmentId)
        {
            return await _dataset.AnyAsync((establishmentPeriod) =>
                    establishmentPeriod.DayOfWeek.ToLower() == dayOfWeek.ToLower() &&
                    establishmentPeriod.EstablishmentId == establishmentId);
        }
    }
}
