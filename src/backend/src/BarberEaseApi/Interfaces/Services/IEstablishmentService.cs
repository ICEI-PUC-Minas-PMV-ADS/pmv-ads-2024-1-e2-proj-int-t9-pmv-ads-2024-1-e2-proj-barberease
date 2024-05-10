using BarberEaseApi.Dtos.Establishment;

namespace BarberEaseApi.Interfaces.Services
{
    public interface IEstablishmentService
    {
        Task<EstablishmentDto?> Create(EstablishmentDtoCreate establishment);
        Task<IEnumerable<EstablishmentDto>> GetAll();
        Task<EstablishmentDto?> GetById(Guid id);
        Task<EstablishmentDto?> Update(EstablishmentDtoUpdate establishment, Guid id);
        Task<bool> Delete(Guid id);
    }
}
