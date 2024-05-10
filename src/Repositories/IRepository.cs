using DomainDrivenFramework.Entities;

namespace DomainDrivenFramework.Repositories
{
    public interface IRepository<T>
        where T : AggregateRoot
    {
        IQueryable<T> GetAll(bool noTracking = true);
        Task<T?> GetById(Guid id, CancellationToken cancellationToken = default, bool noTracking = false);
        void Insert(T entity);
        void Insert(List<T> entities);
        void Delete(T entity);
        void Remove(IEnumerable<T> entitiesToRemove);
    }
}
