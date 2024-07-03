using Domain.Interfaces.Repositiries;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection.Metadata.Ecma335;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IGenericRepository<User> _repository;

        public CreateUserCommandHandler(IGenericRepository<User> genericRepository)
        {
                _repository = genericRepository;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                CreatedAt = DateTime.UtcNow,
            };
            return await _repository.CreateAsync(user);
        }
    }
}
