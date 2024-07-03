using Domain.Helpers;
using MediatR;
using Domain.Models;

namespace Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<ServiceResponse<User>>
    {
        public Guid Id { get; set; }
    }
}
