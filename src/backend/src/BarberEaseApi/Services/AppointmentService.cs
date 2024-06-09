using AutoMapper;
using BarberEaseApi.Dtos.Appointment;
using BarberEaseApi.Entities;
using BarberEaseApi.Interfaces.Repositories;
using BarberEaseApi.Interfaces.Services;

namespace BarberEaseApi.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public AppointmentService(
            IAppointmentRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AppointmentDto?> Create(AppointmentCreateDto appointment)
        {
            var appointmentExists = await _repository.ExistsByDateAndService(appointment.Date, appointment.EstablishmentServiceId);

            if (appointmentExists)
            {
                return null;
            }

            var entity = _mapper.Map<AppointmentEntity>(appointment);
            var result = await _repository.CreateAsync(entity);
            return _mapper.Map<AppointmentDto>(result);
        }

        public async Task<IEnumerable<AppointmentDetailsDto>> GetAllDetails()
        {
            var entities = await _repository.FindAllDetails();
            return _mapper.Map<IEnumerable<AppointmentDetailsDto>>(entities);
        }

        public async Task<AppointmentDetailsDto?> GetByIdDetails(Guid id)
        {
            var entity = await _repository.FindByIdDetails(id);
            return _mapper.Map<AppointmentDetailsDto>(entity);
        }

        public async Task<AppointmentDto?> UpdateStatus(AppointmentUpdateStatusDto appointment, Guid id)
        {
            var result = await _repository.UpdateStatus(appointment.Status, id);
            return _mapper.Map<AppointmentDto>(result);
        }
    }
}
