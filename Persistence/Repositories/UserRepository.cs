using Application.Common.DTOs;
using Application.Interfaces.Repositiries;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public UserRepository(ApplicationDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        public async Task<ServiceDataResponse<UserDTO>> CreateUserAsync(UserDTO userDTO)
        {
            if(userDTO == null)
            {
                return ServiceDataResponse<UserDTO>.Failed("User cannot be null");
            }

            if (await _dbcontext.Users.AnyAsync(e => e.Email == userDTO.Email)) 
            {
                return ServiceDataResponse<UserDTO>.Failed("Account with this email already exist");
            }

            var userId = Guid.NewGuid();
            userDTO.Id = userId;

            var user = _mapper.Map<User>(userDTO);
            
            await _dbcontext.AddAsync(user);

            return ServiceDataResponse<UserDTO>.Succeeded(userDTO);
        }
    }
}
