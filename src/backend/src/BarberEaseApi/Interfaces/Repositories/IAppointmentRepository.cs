using BarberEaseApi.Dtos.Appointment;
using BarberEaseApi.Entities;

namespace BarberEaseApi.Interfaces.Repositories
{
    public interface IAppointmentRepository : IRepository<AppointmentEntity>
    {
        Task<IEnumerable<AppointmentEntity>> FindAllDetails();
        Task<AppointmentEntity?> FindByIdDetails(Guid id);
        Task<AppointmentEntity?> UpdateStatus(string status, Guid id);
        Task<bool> ExistsByDateAndService(DateTime date, Guid establishmentServiceId);
    }
}
