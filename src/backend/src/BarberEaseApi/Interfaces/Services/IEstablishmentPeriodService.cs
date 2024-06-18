using BarberEaseApi.Dtos.EstablishmentPeriod;

namespace BarberEaseApi.Interfaces.Services
{
    public interface IEstablishmentPeriodService
    {
        Task<EstablishmentPeriodDto?> Create(EstablishmentPeriodCreateDto establishmentPeriod);
        Task<IEnumerable<EstablishmentPeriodDto>> GetAll();
        Task<IEnumerable<EstablishmentPeriodDto>> GetByEstablishmentId(Guid establishmentId);
        Task<EstablishmentPeriodDto?> GetById(Guid id);
        Task<EstablishmentPeriodDto?> Update(EstablishmentPeriodUpdateDto establishmentPeriod, Guid id);
        Task<bool> Delete(Guid id);
    }
}
