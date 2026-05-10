using PersonService.Domain.Common;

namespace PersonService.Domain.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity, CancellationToken ct = default);
        Task<T?> UpdateAsync(T entity, CancellationToken ct = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
