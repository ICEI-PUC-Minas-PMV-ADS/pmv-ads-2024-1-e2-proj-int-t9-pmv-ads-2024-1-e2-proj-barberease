using BarberEaseApi.Dtos.EstablishmentService;

namespace BarberEaseApi.Interfaces.Services
{
    public interface IEstablishmentServiceService
    {
        Task<EstablishmentServiceDto?> Create(EstablishmentServiceCreateDto establishmentService);
        Task<IEnumerable<EstablishmentServiceDto>> GetAll();
        Task<IEnumerable<EstablishmentServiceDto>> GetByEstablishmentId(Guid establishmentId);
        Task<EstablishmentServiceDto?> GetById(Guid id);
        Task<EstablishmentServiceDto?> Update(EstablishmentServiceUpdateDto establishmentService, Guid id);
        Task<bool> Delete(Guid id);
    }
}
