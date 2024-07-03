using Application.Common.Exceptions;
using Domain.Helpers;
using Domain.Interfaces.Repositiries;
using Domain.Models;
using MediatR;
using AutoMapper;
using System.Runtime.CompilerServices;

namespace Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand,ServiceResponse<User>>
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IGenericRepository<User> genericRepository,IMapper mapper)
        {
            _repository = genericRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<User>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var serviceResponse = await _repository.GetByIdAsync(request.Id);
            if (serviceResponse == null)
            {
                throw new NotFoundException(nameof(serviceResponse));
            }

            var user = _mapper.Map<User>(serviceResponse);

           return await _repository.DeleteAsync(user.Id);
        }
    }
}
