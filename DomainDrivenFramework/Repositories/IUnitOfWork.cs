using DomainDrivenFramework.Entities;

namespace DomainDrivenFramework.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync(CancellationToken cancellationToken = default);
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : AggregateRoot;
    }
}
