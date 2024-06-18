using BarberEaseApi.Entities;

namespace BarberEaseApi.Interfaces.Repositories
{
    public interface IEstablishmentPeriodRepository : IRepository<EstablishmentPeriodEntity>
    {
        Task<IEnumerable<EstablishmentPeriodEntity>> FindAllByEstablishment(Guid establishmentId);
        Task<bool> ExistsByDayOfWeekAndEstablishment(string dayOfWeek, Guid establishmentId);
    }
}
