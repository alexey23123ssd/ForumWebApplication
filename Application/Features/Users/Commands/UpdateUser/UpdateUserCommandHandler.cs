using Application.Common.Exceptions;
using AutoMapper;
using Application.Interfaces.Repositiries;
using MediatR;
using Application.Common.DTOs;
using Domain.Helpers;
using Domain.Models;
using Application.Interfaces;

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ServiceDataResponse<UserDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceDataResponse<UserDTO>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var serviceDataResponse = await _unitOfWork.Repository<User>().GetByIdAsync(request.Id);

            if (serviceDataResponse == null)
            {
                throw new NotFoundException(nameof(serviceDataResponse));
            }

            var user = serviceDataResponse.Data;

            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;
            user.UpdatedAt = DateTime.UtcNow;

            var userId = user.Id;

            var userDTO = _mapper.Map<UserDTO>(user);

            await _unitOfWork.Repository<User>().UpdateAsync(userId,user);
            await _unitOfWork.Save(cancellationToken);

            return ServiceDataResponse<UserDTO>.Succeeded(userDTO);

        }
    }
}
