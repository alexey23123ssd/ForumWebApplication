using Application.Common.DTOs;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<ServiceDataResponse<UserDTO>>
    {
        public Guid id { get; set; }
    }
}
