using BarberEaseApi.Entities;
using BarberEaseApi.Interfaces.Repositories;
using BarberEaseApi.Interfaces.Services;

namespace BarberEaseApi.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<ClientEntity> _repository;

        public ClientService(IRepository<ClientEntity> repository)
        {
            _repository = repository;
        }

        public async Task<ClientEntity> Create(ClientEntity client)
        {
            client.SetPassword(client.HashedPassword);
            return await _repository.CreateAsync(client);
        }

        public async Task<IEnumerable<ClientEntity>> GetAll()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<ClientEntity?> GetById(Guid id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<ClientEntity?> Update(ClientEntity client)
        {
            return await _repository.UpdateAsync(client);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
