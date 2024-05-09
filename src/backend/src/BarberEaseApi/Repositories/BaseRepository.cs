using BarberEaseApi.Database;
using BarberEaseApi.Entities;
using BarberEaseApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberEaseApi.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dataset;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T item)
        {
            try
            {
                item.Id = Guid.NewGuid();
                item.CreatedAt = DateTime.UtcNow;
                item.UpdatedAt = DateTime.UtcNow;

                _dataset.Add(item);

                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T?> FindByIdAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync((entity) => entity.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T?> UpdateAsync(T item, Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync((entity) => entity.Id == id);
                if (result == null)
                {
                    return null;
                }

                item.Id = result.Id;
                item.CreatedAt = result.CreatedAt;
                item.UpdatedAt = DateTime.UtcNow;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();

                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync((entity) => entity.Id == id);
                if (result == null)
                {
                    return false;
                }

                _dataset.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dataset.AnyAsync((entity) => entity.Id == id);
        }
    }
}
