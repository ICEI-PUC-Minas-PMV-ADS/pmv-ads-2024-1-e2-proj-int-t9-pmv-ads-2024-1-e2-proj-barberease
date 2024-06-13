using BarberEaseApi.Dtos.Appointment;

namespace BarberEaseApi.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<AppointmentDto?> Create(AppointmentCreateDto appointment);
        Task<IEnumerable<AppointmentDetailsDto>> GetAllDetails();
        Task<IEnumerable<AppointmentDetailsDto>> GetByClentIdDetails(Guid clientId);
        Task<AppointmentDetailsDto?> GetByIdDetails(Guid id);
        Task<AppointmentDto?> UpdateStatus(AppointmentUpdateStatusDto appointment, Guid id);
    }
}
