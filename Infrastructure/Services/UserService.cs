using AutoMapper;
using Domain.Helpers;
using Domain.Interfaces.Repositiries;
using Domain.Models;
using ForumWebApplication.DTOs;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
namespace Infrastructure.Services
{
    public class UserService : IGenericRepository<UserDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }
        public async Task<ServiceDataResponse<UserDTO>> CreateAsync(UserDTO entity)
        {
            if(entity == null)
            {
                return ServiceDataResponse<UserDTO>.Failed("Entity cannot be null");
            }

            if(await _dbContext.Users.AnyAsync(e => e.Email == entity.Email)) 
            {
                return ServiceDataResponse<UserDTO>.Failed("Account with this email already exist");
            }

            var userId = Guid.NewGuid();
            var user = _mapper.Map<User>(entity);
            user.Id = userId;
    

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return ServiceDataResponse<UserDTO>.Succeeded(entity);
            
        }

        public async Task<ServiceResponse<UserDTO>> DeleteAsync(Guid id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            if(user == null)
            {
                return ServiceResponse<UserDTO>.Failed("User doesnt exist");
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return ServiceResponse<UserDTO>.Succeeded();
        }

        public Task<ServiceDataResponse<IEnumerable<UserDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceDataResponse<UserDTO>> GetByIdAsync(Guid id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return ServiceDataResponse<UserDTO>.Failed("User with this id doesnt exist");
            }

            var userDTO = _mapper.Map<UserDTO>(user);

            return ServiceDataResponse<UserDTO>.Succeeded(userDTO);
        }

        public async Task<ServiceDataResponse<UserDTO>> UpdateAsync(UserDTO entity)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == entity.Id);

            if(user == null)
            {
                return ServiceDataResponse<UserDTO>.Failed("User doesnt exist");
            }

            _dbContext.Users.Update(user);

            await _dbContext.SaveChangesAsync();

            var userDTO = _mapper.Map<UserDTO>(user);

            return ServiceDataResponse<UserDTO>.Succeeded(userDTO);
        }
    }
}
