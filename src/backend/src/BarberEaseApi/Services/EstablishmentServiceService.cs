using AutoMapper;
using BarberEaseApi.Dtos.EstablishmentService;
using BarberEaseApi.Entities;
using BarberEaseApi.Interfaces.Repositories;
using BarberEaseApi.Interfaces.Services;

namespace BarberEaseApi.Services
{
    public class EstablishmentServiceService : IEstablishmentServiceService
    {
        private readonly IEstablishmentServiceRepository _repository;
        private readonly IMapper _mapper;

        public EstablishmentServiceService(
            IEstablishmentServiceRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EstablishmentServiceDto?> Create(EstablishmentServiceCreateDto establishmentService)
        {
            var establishmentServiceExists = await _repository.ExistsByNameAndEstablishment(
                establishmentService.Name,
                establishmentService.EstablishmentId
            );

            if (establishmentServiceExists)
            {
                return null;
            }

            var entity = _mapper.Map<EstablishmentServiceEntity>(establishmentService);
            var result = await _repository.CreateAsync(entity);
            return _mapper.Map<EstablishmentServiceDto>(result);
        }

        public async Task<IEnumerable<EstablishmentServiceDto>> GetAll()
        {
            var entities = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<EstablishmentServiceDto>>(entities);
        }

        public async Task<EstablishmentServiceDto?> GetById(Guid id)
        {
            var entity = await _repository.FindByIdAsync(id);
            return _mapper.Map<EstablishmentServiceDto>(entity);
        }

        public async Task<EstablishmentServiceDto?> Update(EstablishmentServiceUpdateDto establishmentService, Guid id)
        {
            var entity = _mapper.Map<EstablishmentServiceEntity>(establishmentService);
            var result = await _repository.UpdateAsync(entity, id);
            return _mapper.Map<EstablishmentServiceDto>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
