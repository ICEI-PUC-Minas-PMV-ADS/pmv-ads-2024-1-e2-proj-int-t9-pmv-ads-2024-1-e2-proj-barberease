using BarberEaseApi.Database;
using BarberEaseApi.Entities;
using BarberEaseApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberEaseApi.Repositories
{
    public class AppointmentRepository : BaseRepository<AppointmentEntity>, IAppointmentRepository
    {
        private readonly DbSet<AppointmentEntity> _dataset;

        public AppointmentRepository(AppDbContext context) : base(context)
        {
            _dataset = context.Set<AppointmentEntity>();
        }

        public async Task<IEnumerable<AppointmentEntity>> FindAllDetails()
        {
            return await _dataset
                .Include((establishmentService) => establishmentService.EstablishmentService)
                .ThenInclude((establishmentService) => establishmentService.Establishment)
                .Include((client) => client.Client)
                .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentEntity>> FindAllByClientDetails(Guid clientId)
        {
            return await _dataset
                .Include((establishmentService) => establishmentService.EstablishmentService)
                .ThenInclude((establishmentService) => establishmentService.Establishment)
                .Include((client) => client.Client)
                .Where((appointment) => appointment.ClientId == clientId)
                .OrderByDescending((appointment) => appointment.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentEntity>> FindAllByEstablishmentDetails(Guid establishmentId)
        {
            return await _dataset
                .Include((establishmentService) => establishmentService.EstablishmentService)
                .ThenInclude((establishmentService) => establishmentService.Establishment)
                .Include((client) => client.Client)
                .Where((appointment) => appointment.EstablishmentService.Establishment.Id == establishmentId)
                .OrderByDescending((appointment) => appointment.Date)
                .ToListAsync();
        }

        public async Task<AppointmentEntity?> FindByIdDetails(Guid id)
        {
            try
            {
                return await _dataset
                    .Include((establishmentService) => establishmentService.EstablishmentService)
                    .Include((client) => client.Client)
                    .SingleOrDefaultAsync((entity) => entity.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AppointmentEntity?> UpdateStatus(string status, Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync((entity) => entity.Id == id);
                if (result == null)
                {
                    return null;
                }

                result.Status = status;
                result.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> ExistsByDateAndService(DateTime date, Guid establishmentServiceId)
        {
            return await _dataset.AnyAsync((appointment) =>
                appointment.Date == date &&
                appointment.EstablishmentServiceId == establishmentServiceId);
        }
    }
}
