using BarberEaseApi.Dtos.Client;

namespace BarberEaseApi.Interfaces.Services
{
    public interface IClientService
    {
        Task<ClientDto?> Create(ClientDtoCreate client);
        Task<IEnumerable<ClientDto>> GetAll();
        Task<ClientDto?> GetById(Guid id);
        Task<ClientDto?> Update(ClientDtoUpdate client, Guid id);
        Task<bool> Delete(Guid id);
    }
}
