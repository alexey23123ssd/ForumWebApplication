using Application.Common.DTOs;
using Application.Interfaces;
using Application.Interfaces.Repositiries;
using Application.Interfaces.Repositories;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,ServiceDataResponse<UserDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceDataResponse<UserDTO>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserDTO
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                CreatedAt = DateTime.UtcNow,
            };

            await _unitOfWork.userRepository.CreateUserAsync(user);
            await _unitOfWork.Save(cancellationToken);

            return ServiceDataResponse<UserDTO>.Succeeded(user);
        }
    }
}
