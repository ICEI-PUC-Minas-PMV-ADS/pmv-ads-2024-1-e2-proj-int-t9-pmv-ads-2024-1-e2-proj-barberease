using BarberEaseApi.Entities;

namespace BarberEaseApi.Interfaces.Repositories
{
    public interface IEstablishmentRepository : IRepository<EstablishmentEntity>
    {
        Task<EstablishmentEntity?> FindByEmail(string email);
        Task<EstablishmentEntity?> FindByCnpj(string cnpj);
    }
}
