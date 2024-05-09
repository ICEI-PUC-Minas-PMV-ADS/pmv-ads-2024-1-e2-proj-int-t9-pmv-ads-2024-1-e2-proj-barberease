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

        public async Task<ClientDto?> Create(ClientDtoCreate client)
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

        public async Task<ClientDto?> Update(ClientDtoUpdate client, Guid id)
        {
            var entity = _mapper.Map<ClientEntity>(client);
            var result = await _repository.UpdateAsync(entity, id);
            return _mapper.Map<ClientDto>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
