using BarberEaseApi.Entities;

namespace BarberEaseApi.Interfaces.Repositories
{
    public interface IAppointmentRepository : IRepository<AppointmentEntity>
    {
        Task<AppointmentEntity?> UpdateStatusAsync(string status, Guid id);
    }
}
