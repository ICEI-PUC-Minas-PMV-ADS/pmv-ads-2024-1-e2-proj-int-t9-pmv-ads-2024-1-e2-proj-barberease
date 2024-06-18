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
        private readonly IEstablishmentServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public AppointmentService(
            IAppointmentRepository repository,
            IEstablishmentServiceRepository serviceRepository,
            IMapper mapper)
        {
            _repository = repository;
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<AppointmentDto?> Create(AppointmentCreateDto appointment)
        {
            var result = await _serviceRepository.FindByIdAsync(appointment.EstablishmentServiceId);
            if (result == null)
            {
                return null;
            }
            var appointmentExists = await _repository.ExistsByDateAndEstablishment(appointment.Date, result.EstablishmentId);
            if (appointmentExists)
            {
                return null;
            }

            var entity = _mapper.Map<AppointmentEntity>(appointment);
            var createResult = await _repository.CreateAsync(entity);
            return _mapper.Map<AppointmentDto>(createResult);
        }

        public async Task<IEnumerable<AppointmentDetailsDto>> GetAllDetails()
        {
            var entities = await _repository.FindAllDetails();
            return _mapper.Map<IEnumerable<AppointmentDetailsDto>>(entities);
        }

        public async Task<IEnumerable<AppointmentDetailsDto>> GetByClentIdDetails(Guid clientId)
        {
            var entities = await _repository.FindAllByClientDetails(clientId);
            return _mapper.Map<IEnumerable<AppointmentDetailsDto>>(entities);
        }

        public async Task<IEnumerable<AppointmentDetailsDto>> GetByEstablishmentIdDetails(Guid establishmentId)
        {
            var entities = await _repository.FindAllByEstablishmentDetails(establishmentId);
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
