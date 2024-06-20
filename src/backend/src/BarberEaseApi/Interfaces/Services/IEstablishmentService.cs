using BarberEaseApi.Dtos.Establishment;

namespace BarberEaseApi.Interfaces.Services
{
    public interface IEstablishmentService
    {
        Task<EstablishmentDto?> Create(EstablishmentCreateDto establishment);
        Task<IEnumerable<EstablishmentDto>> GetAll();
        Task<IEnumerable<EstablishmentDetailsDto>> GetAllDetails();
        Task<EstablishmentDto?> GetById(Guid id);
        Task<EstablishmentDetailsDto?> GetByIdDetails(Guid id);
        Task<EstablishmentDto?> Update(EstablishmentUpdateDto establishment, Guid id);
        Task<EstablishmentDto?> PartialUpdate(EstablishmentPartialtUpdateDto establishment, Guid id);
        Task<bool> Delete(Guid id);
    }
}
