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

        public async Task<AppointmentEntity?> UpdateStatusAsync(string status, Guid id)
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
    }
}
