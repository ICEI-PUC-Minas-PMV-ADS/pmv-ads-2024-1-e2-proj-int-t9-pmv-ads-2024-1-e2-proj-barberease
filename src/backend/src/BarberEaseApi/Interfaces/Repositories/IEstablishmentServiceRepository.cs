using BarberEaseApi.Entities;

namespace BarberEaseApi.Interfaces.Repositories
{
    public interface IEstablishmentServiceRepository : IRepository<EstablishmentServiceEntity>
    {
        Task<bool> ExistsByNameAndEstablishment(string name, Guid establishmentId);
    }
}
