using BarberEaseApi.Entities;

namespace BarberEaseApi.Interfaces.Repositories
{
    public interface IEstablishmentPeriodRepository : IRepository<EstablishmentPeriodEntity>
    {
        Task<bool> ExistsByDayOfWeekAndEstablishment(string dayOfWeek, Guid establishmentId);
    }
}
