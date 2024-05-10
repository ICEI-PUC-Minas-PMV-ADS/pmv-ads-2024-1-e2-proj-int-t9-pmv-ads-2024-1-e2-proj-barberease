using AutoMapper;
using BarberEaseApi.Dtos.Establishment;
using BarberEaseApi.Entities;
using BarberEaseApi.Interfaces.Repositories;
using BarberEaseApi.Interfaces.Services;

namespace BarberEaseApi.Services
{
    public class EstablishmentService : IEstablishmentService
    {
        private readonly IEstablishmentRepository _repository;
        private readonly IMapper _mapper;

        public EstablishmentService(IEstablishmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EstablishmentDto?> Create(EstablishmentDtoCreate establishment)
        {
            var existsByEmail = await _repository.FindByEmail(establishment.Email);
            if (existsByEmail != null)
            {
                return null;
            }

            var existsByCnpj = await _repository.FindByCnpj(establishment.Cnpj);
            if (existsByCnpj != null)
            {
                return null;
            }

            var entity = _mapper.Map<EstablishmentEntity>(establishment);
            entity.SetPassword(establishment.Password);
            var result = await _repository.CreateAsync(entity);
            return _mapper.Map<EstablishmentDto>(result);
        }

        public async Task<IEnumerable<EstablishmentDto>> GetAll()
        {
            var entities = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<EstablishmentDto>>(entities);
        }

        public async Task<EstablishmentDto?> GetById(Guid id)
        {
            var entity = await _repository.FindByIdAsync(id);
            return _mapper.Map<EstablishmentDto>(entity);
        }

        public async Task<EstablishmentDto?> Update(EstablishmentDtoUpdate establishment, Guid id)
        {
            var entity = _mapper.Map<EstablishmentEntity>(establishment);
            if (establishment.Password != null)
            {
                entity.SetPassword(establishment.Password);
            }
            var result = await _repository.UpdateAsync(entity, id);
            return _mapper.Map<EstablishmentDto>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
