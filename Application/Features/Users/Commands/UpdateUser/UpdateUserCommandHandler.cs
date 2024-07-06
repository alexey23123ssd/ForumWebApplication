using Application.Common.Exceptions;
using AutoMapper;
using Domain.Interfaces.Repositiries;
using MediatR;
using Application.Common.DTOs;
using Domain.Helpers;
using Domain.Models;

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ServiceDataResponse<UserDTO>>
    {
        private readonly IGenericRepository<UserDTO> _repository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IGenericRepository<UserDTO> genericRepository, IMapper mapper)
        {
            _repository = genericRepository;
            _mapper = mapper;
        }

        public async Task<ServiceDataResponse<UserDTO>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var serviceDataResponse = await _repository.GetByIdAsync(request.Id);
            if (serviceDataResponse == null)
            {
                throw new NotFoundException(nameof(serviceDataResponse));
            }
            var user = _mapper.Map<UserDTO>(serviceDataResponse);

            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;
            user.UpdatedAt = request.UpdatedAt;

            return await _repository.UpdateAsync(user);
        }
    }
}
