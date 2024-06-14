using BarberEaseApi.Dtos.Appointment;
using BarberEaseApi.Entities;

namespace BarberEaseApi.Interfaces.Repositories
{
    public interface IAppointmentRepository : IRepository<AppointmentEntity>
    {
        Task<IEnumerable<AppointmentEntity>> FindAllDetails();
        Task<IEnumerable<AppointmentEntity>> FindAllByClientDetails(Guid clientId);
        Task<IEnumerable<AppointmentEntity>> FindAllByEstablishmentDetails(Guid establishmentId);
        Task<AppointmentEntity?> FindByIdDetails(Guid id);
        Task<AppointmentEntity?> UpdateStatus(string status, Guid id);
        Task<bool> ExistsByDateAndService(DateTime date, Guid establishmentServiceId);
    }
}
