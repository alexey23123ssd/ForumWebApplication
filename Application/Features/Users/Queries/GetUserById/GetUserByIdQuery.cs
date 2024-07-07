using Application.Common.DTOs;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<ServiceDataResponse<UserDTO>>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id)
        {
          Id = id;
        }
    }
}
