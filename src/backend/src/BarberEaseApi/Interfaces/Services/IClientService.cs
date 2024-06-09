using BarberEaseApi.Dtos.Client;

namespace BarberEaseApi.Interfaces.Services
{
    public interface IClientService
    {
        Task<ClientDto?> Create(ClientCreateDto client);
        Task<IEnumerable<ClientDto>> GetAll();
        Task<ClientDto?> GetById(Guid id);
        Task<ClientDto?> Update(ClientUpdateDto client, Guid id);
        Task<bool> Delete(Guid id);
    }
}
