using Application.Common.DTOs;
using Domain.Helpers;
using Application.Interfaces.Repositiries;
using MediatR;
using Domain.Models;
using Application.Interfaces;
using System.Runtime.CompilerServices;
using AutoMapper;

namespace Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ServiceDataResponse<UserDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceDataResponse<UserDTO>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Repository<User>().GetByIdAsync(query.Id);
            var entity = result.Data;

            var user = _mapper.Map<UserDTO>(entity);

            return ServiceDataResponse<UserDTO>.Succeeded(user);
        }
    }
}
