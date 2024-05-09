using BarberEaseApi.Database;
using BarberEaseApi.Entities;
using BarberEaseApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberEaseApi.Repositories
{
    public class EstablishmentRepository : BaseRepository<EstablishmentEntity>, IEstablishmentRepository
    {
        private readonly DbSet<EstablishmentEntity> _dataset;

        public EstablishmentRepository(AppDbContext context) : base(context)
        {
            _dataset = context.Set<EstablishmentEntity>();
        }

        public async Task<EstablishmentEntity?> FindByEmail(string email)
        {
            try
            {
                return await _dataset.FirstOrDefaultAsync((establishment) => establishment.Email == email);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
