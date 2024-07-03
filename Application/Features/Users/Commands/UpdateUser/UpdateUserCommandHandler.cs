using Application.Common.Exceptions;
using AutoMapper;
using Domain.Interfaces.Repositiries;
using Domain.Models;
using MediatR;

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IGenericRepository<User> genericRepository, IMapper mapper)
        {
            _repository = genericRepository;
            _mapper = mapper;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException(nameof(user));
            }

            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;
            user.UpdatedAt = request.UpdatedAt;

            return await _repository.UpdateAsync(user);
        }
    }
}
