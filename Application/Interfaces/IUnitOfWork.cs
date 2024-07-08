using Application.Interfaces.Repositiries;
using Domain;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseEntity;
        Task<int> Save(CancellationToken cancellationToken);
        Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);
        Task Rollback();
    }
}
