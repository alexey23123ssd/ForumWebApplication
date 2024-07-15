using Application.Common.DTOs;
using Domain.Helpers;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<ServiceDataResponse<UserDTO>> CreateUserAsync(UserDTO user);
    }
}
