using Application.Common.Exceptions;
using Domain.Helpers;
using Application.Interfaces.Repositiries;
using Domain.Models;
using MediatR;
using AutoMapper;
using Application.Common.DTOs;
using System.Runtime.CompilerServices;
using Application.Interfaces;

namespace Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand,ServiceResponse<UserDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<UserDTO>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var serviceResponse = await _unitOfWork.Repository<User>().GetByIdAsync(request.Id);
            if (serviceResponse == null)
            {
                throw new NotFoundException(nameof(serviceResponse));
            }

            var user = serviceResponse.Data;
            var userId = user.Id;

            var userDTO = _mapper.Map<UserDTO>(user);

            await _unitOfWork.Repository<User>().DeleteAsync(userId);
            await _unitOfWork.Save(cancellationToken);

            return ServiceResponse<UserDTO>.Succeeded();
        }
    }
}
