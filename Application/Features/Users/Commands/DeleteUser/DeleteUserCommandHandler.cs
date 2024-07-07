using Application.Common.Exceptions;
using Domain.Helpers;
using Application.Interfaces.Repositiries;
using Domain.Models;
using MediatR;
using AutoMapper;
using Application.Common.DTOs;
using System.Runtime.CompilerServices;

namespace Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand,ServiceResponse<UserDTO>>
    {
        private readonly IGenericRepository<UserDTO> _repository;

        public DeleteUserCommandHandler(IGenericRepository<UserDTO> genericRepository)
        {
            _repository = genericRepository;
        }

        public async Task<ServiceResponse<UserDTO>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var serviceResponse = await _repository.GetByIdAsync(request.Id);
            if (serviceResponse == null)
            {
                throw new NotFoundException(nameof(serviceResponse));
            }

            var user = serviceResponse.Data;

           return await _repository.DeleteAsync(user.Id);
        }
    }
}
