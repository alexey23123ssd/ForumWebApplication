using Domain.Helpers;
namespace Domain.Interfaces.Repositiries
{
    public interface IGenericRepository<T> where T : class, IBaseEntity
    {
        Task<ServiceDataResponse<T>> CreateAsync(T entity);
        Task<ServiceDataResponse<T>> UpdateAsync(Guid id);
        Task<ServiceResponse<T>> DeleteAsync(Guid id);
        Task<ServiceDataResponse<T>> GetByIdAsync(Guid id);
        Task<ServiceDataResponse<IEnumerable<T>>> GetAllAsync();
    }
}
