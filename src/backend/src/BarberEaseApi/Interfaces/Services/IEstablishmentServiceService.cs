using BarberEaseApi.Dtos.EstablishmentService;

namespace BarberEaseApi.Interfaces.Services
{
    public interface IEstablishmentServiceService
    {
        Task<EstablishmentServiceDto?> Create(EstablishmentServiceCreateDto establishmentService);
        Task<IEnumerable<EstablishmentServiceDetailsDto>> GetAll();
        Task<EstablishmentServiceDetailsDto?> GetById(Guid id);
        Task<EstablishmentServiceDto?> Update(EstablishmentServiceCreateDto establishmentService, Guid id);
        Task<bool> Delete(Guid id);
    }
}
