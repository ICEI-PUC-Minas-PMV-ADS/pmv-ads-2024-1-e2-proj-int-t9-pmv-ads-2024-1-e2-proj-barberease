using BarberEaseApi.Database;
using BarberEaseApi.Entities;
using BarberEaseApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberEaseApi.Repositories
{
    public class ClientRepository : BaseRepository<ClientEntity>, IClientRepository
    {
        private readonly DbSet<ClientEntity> _dataset;

        public ClientRepository(AppDbContext context) : base(context)
        {
            _dataset = context.Set<ClientEntity>();
        }

        public async Task<ClientEntity?> FindByEmail(string email)
        {
            try
            {
                return await _dataset.FirstOrDefaultAsync((client) => client.Email == email);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
