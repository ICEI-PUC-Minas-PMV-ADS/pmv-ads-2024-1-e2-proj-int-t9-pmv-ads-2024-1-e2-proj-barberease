using BarberEaseApi.Entities;

namespace BarberEaseApi.Interfaces.Services
{
    public interface IClientService
    {
        Task<ClientEntity> Create(ClientEntity client);
        Task<IEnumerable<ClientEntity>> GetAll();
        Task<ClientEntity?> GetById(Guid id);
        Task<ClientEntity?> Update(ClientEntity client);
        Task<bool> Delete(Guid id);
    }
}
