using Domain;
using Domain.Helpers;
namespace Application.Interfaces.Repositiries
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<ServiceDataResponse<T>> CreateAsync(T entity);
        Task<ServiceDataResponse<T>> UpdateAsync(T entity);
        Task<ServiceResponse<T>> DeleteAsync(Guid id);
        Task<ServiceDataResponse<T>> GetByIdAsync(Guid id);
        Task<ServiceDataResponse<IEnumerable<T>>> GetAllAsync();
    }
}
