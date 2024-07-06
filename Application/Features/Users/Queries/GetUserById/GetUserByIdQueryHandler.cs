using Application.Common.DTOs;
using Domain.Helpers;
using Domain.Interfaces.Repositiries;
using MediatR;

namespace Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ServiceDataResponse<UserDTO>>
    {
        private readonly IGenericRepository<UserDTO> _repository;

        public GetUserByIdQueryHandler(IGenericRepository<UserDTO> genericRepository)
        {
                _repository = genericRepository;
        }

        public async Task<ServiceDataResponse<UserDTO>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(query.id);
        }
    }
}
