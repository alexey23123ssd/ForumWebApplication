using Application.Interfaces.Repositiries;
using Domain;
using Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbcontext;

        public GenericRepository(ApplicationDbContext context)
        {
           _dbcontext = context;
        }
        public IQueryable<T> Entities => _dbcontext.Set<T>();

        public async Task<ServiceDataResponse<T>> CreateAsync(T entity)
        {
            if(entity == null)
            {
                return ServiceDataResponse<T>.Failed("Entity cannot be null");
            }

            var entityId = Guid.NewGuid();
            entity.Id = entityId;

            await _dbcontext.Set<T>().AddAsync(entity);

            return ServiceDataResponse<T>.Succeeded(entity);
        }

        public async Task<ServiceResponse<T>> DeleteAsync(Guid id)
        {
            var entity = _dbcontext.Set<T>().SingleOrDefault(x => x.Id == id);
            
            if(entity == null)
            {
                return ServiceDataResponse<T>.Failed("Entity with this id not found");
            }

            _dbcontext.Set<T>().Remove(entity);

            return ServiceDataResponse<T>.Succeeded();
        }

        public Task<ServiceDataResponse<IEnumerable<T>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceDataResponse<T>> GetByIdAsync(Guid id)
        {
            var entity = _dbcontext.Set<T>().SingleOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return ServiceDataResponse<T>.Failed("Entity with this id not found");
            }

            await _dbcontext.Set<T>().FindAsync(id);

            return ServiceDataResponse<T>.Succeeded(entity);
        }

        public async Task<ServiceDataResponse<T>> UpdateAsync(Guid id,T entity)
        {
            var model = _dbcontext.Set<T>().SingleOrDefault(x => x.Id == id);

            if (model == null)
            {
                return ServiceDataResponse<T>.Failed("Entity with this id not found");
            }

            _dbcontext.Entry(model).CurrentValues.SetValues(entity);

            return ServiceDataResponse<T>.Succeeded(entity);
        }
    }
}
