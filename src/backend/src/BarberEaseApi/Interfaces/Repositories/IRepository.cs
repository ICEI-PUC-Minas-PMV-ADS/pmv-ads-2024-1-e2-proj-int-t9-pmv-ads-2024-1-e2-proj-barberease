using BarberEaseApi.Entities;

namespace BarberEaseApi.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> CreateAsync(T item);
        Task<IEnumerable<T>> FindAllAsync();
        Task<T?> FindByIdAsync(Guid id);
        Task<T?> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}
