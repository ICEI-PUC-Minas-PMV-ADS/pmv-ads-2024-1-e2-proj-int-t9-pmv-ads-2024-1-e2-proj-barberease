using BarberEaseApi.Entities;

namespace BarberEaseApi.Interfaces.Repositories
{
    public interface IClientRepository : IRepository<ClientEntity>
    {
        Task<ClientEntity?> FindByEmail(string email);
    }
}
