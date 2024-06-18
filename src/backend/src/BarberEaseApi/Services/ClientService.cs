using AutoMapper;
using BarberEaseApi.Dtos.Client;
using BarberEaseApi.Entities;
using BarberEaseApi.Interfaces.Repositories;
using BarberEaseApi.Interfaces.Services;

namespace BarberEaseApi.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClientDto?> Create(ClientCreateDto client)
        {
            var existsByEmail = await _repository.FindByEmail(client.Email);
            if (existsByEmail != null)
            {
                return null;
            }

            var entity = _mapper.Map<ClientEntity>(client);
            entity.SetPassword(client.Password);
            var result = await _repository.CreateAsync(entity);
            return _mapper.Map<ClientDto>(result);
        }

        public async Task<IEnumerable<ClientDto>> GetAll()
        {
            var entities = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<ClientDto>>(entities);
        }

        public async Task<ClientDto?> GetById(Guid id)
        {
            var entity = await _repository.FindByIdAsync(id);
            return _mapper.Map<ClientDto>(entity);
        }

        public async Task<ClientDto?> Update(ClientUpdateDto client, Guid id)
        {
            var entity = _mapper.Map<ClientEntity>(client);
            if (client.Password != null)
            {
                entity.SetPassword(client.Password);
            }
            var result = await _repository.UpdateAsync(entity, id);
            return _mapper.Map<ClientDto>(result);
        }

        public async Task<ClientDto?> PartialUpdate(ClientPartialUpdateDto client, Guid id)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
            {
                return null;
            }
            var entity = _mapper.Map<ClientEntity>(client);
            if (client.Email == null)
            {
                entity.Email = result.Email;
            }
            else
            {
                if (result.Email != client.Email)
                {

                    var existsByEmail = await _repository.FindByEmail(client.Email);
                    if (existsByEmail != null)
                    {
                        return null;
                    }
                }
            }
            if (client.Password == null)
            {
                entity.HashedPassword = result.HashedPassword;
            }
            else
            {
                entity.SetPassword(client.Password);
            }
            if (client.FirstName == null)
            {
                entity.FirstName = result.FirstName;
            }
            if (client.LastName == null)
            {
                entity.LastName = result.LastName;
            }
            if (client.City == null)
            {
                entity.City = result.City;
            }
            if (client.State == null)
            {
                entity.State = result.State;
            }
            if (client.Phone == null)
            {
                entity.Phone = result.Phone;
            }

            var updateResult = await _repository.UpdateAsync(entity, id);
            return _mapper.Map<ClientDto>(updateResult);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
