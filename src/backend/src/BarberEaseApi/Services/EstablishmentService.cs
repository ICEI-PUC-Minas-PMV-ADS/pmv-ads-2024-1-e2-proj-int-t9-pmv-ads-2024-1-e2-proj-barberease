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

        public async Task<EstablishmentDto?> Create(EstablishmentCreateDto establishment)
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

        public async Task<EstablishmentDetailsDto?> GetByIdDetails(Guid id)
        {
            var entity = await _repository.FindByIdDetails(id);
            return _mapper.Map<EstablishmentDetailsDto>(entity);
        }

        public async Task<EstablishmentDto?> Update(EstablishmentUpdateDto establishment, Guid id)
        {
            var entity = _mapper.Map<EstablishmentEntity>(establishment);
            if (establishment.Password != null)
            {
                entity.SetPassword(establishment.Password);
            }
            var result = await _repository.UpdateAsync(entity, id);
            return _mapper.Map<EstablishmentDto>(result);
        }

        public async Task<EstablishmentDto?> PartialUpdate(EstablishmentPartialtUpdateDto establishment, Guid id)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
            {
                return null;
            }
            var entity = _mapper.Map<EstablishmentEntity>(establishment);
            if (establishment.Email == null)
            {
                entity.Email = result.Email;
            }
            else
            {
                var existsByEmail = await _repository.FindByEmail(establishment.Email);
                if (existsByEmail != null)
                {
                    return null;
                }
            }
            if (establishment.Password == null)
            {
                entity.HashedPassword = result.HashedPassword;
            }
            else
            {
                entity.SetPassword(establishment.Password);
            }
            if (establishment.CompanyName == null)
            {
                entity.CompanyName = result.CompanyName;
            }
            if (establishment.Cnpj == null)
            {
                entity.Cnpj = result.Cnpj;
            }
            else
            {
                var existsByCnpj = await _repository.FindByCnpj(establishment.Cnpj);
                if (existsByCnpj != null)
                {
                    return null;
                }
            }
            if (establishment.OwnerFirstName == null)
            {
                entity.OwnerFirstName = result.OwnerFirstName;
            }
            if (establishment.OwnerLastName == null)
            {
                entity.OwnerLastName = result.OwnerLastName;
            }
            if (establishment.City == null)
            {
                entity.City = result.City;
            }
            if (establishment.State == null)
            {
                entity.State = result.State;
            }
            if (establishment.Cep == null)
            {
                entity.Cep = result.Cep;
            }
            if (establishment.Address == null)
            {
                entity.Address = result.Address;
            }
            if (establishment.Phone == null)
            {
                entity.Phone = result.Phone;
            }

            var updateResult = await _repository.UpdateAsync(entity, id);
            return _mapper.Map<EstablishmentDto>(updateResult);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
