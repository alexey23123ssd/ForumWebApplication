using Application.Common.Exceptions;
using AutoMapper;
using Application.Interfaces.Repositiries;
using MediatR;
using Application.Common.DTOs;
using Domain.Helpers;

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ServiceDataResponse<UserDTO>>
    {
        private readonly IGenericRepository<UserDTO> _repository;

        public UpdateUserCommandHandler(IGenericRepository<UserDTO> genericRepository)
        {
            _repository = genericRepository;
        }

        public async Task<ServiceDataResponse<UserDTO>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var serviceDataResponse = await _repository.GetByIdAsync(request.Id);

            if (serviceDataResponse == null)
            {
                throw new NotFoundException(nameof(serviceDataResponse));
            }

            var user = serviceDataResponse.Data;

            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;
            user.UpdatedAt = DateTime.UtcNow;

            return await _repository.UpdateAsync(user);
        }
    }
}
