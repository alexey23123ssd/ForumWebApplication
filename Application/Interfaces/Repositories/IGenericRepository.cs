using Domain.Helpers;
using Domain;
using Domain.Models;
namespace Domain.Interfaces.Repositiries
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<User> CreateAsync(T entity);
        Task<User> UpdateAsync(T entity);
        Task<ServiceResponse<T>> DeleteAsync(Guid id);
        Task<User> GetByIdAsync(Guid id);
        Task<ServiceDataResponse<IEnumerable<T>>> GetAllAsync();
    }
}
