using AutoMapper;
using BarberEaseApi.Dtos.EstablishmentPeriod;
using BarberEaseApi.Entities;
using BarberEaseApi.Interfaces.Repositories;
using BarberEaseApi.Interfaces.Services;

namespace BarberEaseApi.Services
{
    public class EstablishmentPeriodService : IEstablishmentPeriodService
    {
        private readonly IEstablishmentPeriodRepository _repository;
        private readonly IMapper _mapper;

        public EstablishmentPeriodService(
            IEstablishmentPeriodRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EstablishmentPeriodDto?> Create(EstablishmentPeriodCreateDto establishmentPeriod)
        {
            var establishmentPeriodExists = await _repository.ExistsByDayOfWeekAndEstablishment(
                establishmentPeriod.DayOfWeek,
                establishmentPeriod.EstablishmentId
            );

            if (establishmentPeriodExists)
            {
                return null;
            }

            var entity = _mapper.Map<EstablishmentPeriodEntity>(establishmentPeriod);
            var result = await _repository.CreateAsync(entity);
            return _mapper.Map<EstablishmentPeriodDto>(result);
        }

        public async Task<IEnumerable<EstablishmentPeriodDto>> GetAll()
        {
            var entities = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<EstablishmentPeriodDto>>(entities);
        }

        public async Task<EstablishmentPeriodDto?> GetById(Guid id)
        {
            var entity = await _repository.FindByIdAsync(id);
            return _mapper.Map<EstablishmentPeriodDto>(entity);
        }

        public async Task<EstablishmentPeriodDto?> Update(EstablishmentPeriodUpdateDto establishmentPeriod, Guid id)
        {
            var entity = _mapper.Map<EstablishmentPeriodEntity>(establishmentPeriod);
            var result = await _repository.UpdateAsync(entity, id);
            return _mapper.Map<EstablishmentPeriodDto>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
