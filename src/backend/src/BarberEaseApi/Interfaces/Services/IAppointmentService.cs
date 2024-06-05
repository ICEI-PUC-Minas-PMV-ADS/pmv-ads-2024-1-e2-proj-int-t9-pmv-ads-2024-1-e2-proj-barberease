using BarberEaseApi.Dtos.Appointment;

namespace BarberEaseApi.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<AppointmentDto?> Create(AppointmentCreateDto appointment);
        Task<IEnumerable<AppointmentDetailsDto>> GetAll();
        Task<AppointmentDetailsDto?> GetById(Guid id);
        Task<AppointmentDto?> Update(AppointmentUpdateDto appointment, Guid id);
    }
}
