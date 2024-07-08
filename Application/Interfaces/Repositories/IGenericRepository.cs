using Domain;
using Domain.Helpers;
namespace Application.Interfaces.Repositiries
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> Entities { get; }
        Task<ServiceDataResponse<T>> CreateAsync(T entity);
        Task<ServiceDataResponse<T>> UpdateAsync(Guid id,T entity);
        Task<ServiceResponse<T>> DeleteAsync(Guid id);
        Task<ServiceDataResponse<T>> GetByIdAsync(Guid id);
        Task<ServiceDataResponse<IEnumerable<T>>> GetAllAsync();
    }
}
