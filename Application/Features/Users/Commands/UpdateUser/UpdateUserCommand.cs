using MediatR;
using Application.Common.DTOs;
using Domain.Helpers;

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<ServiceDataResponse<UserDTO>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
