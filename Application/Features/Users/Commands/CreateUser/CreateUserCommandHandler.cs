using Application.Common.DTOs;
using Domain.Helpers;
using Application.Interfaces.Repositiries;
using FluentValidation;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,ServiceDataResponse<UserDTO>>
    {
        private readonly IGenericRepository<UserDTO> _repository;
        private readonly IValidator<CreateUserCommand> _validator;

        public CreateUserCommandHandler(IGenericRepository<UserDTO> genericRepository, IValidator<CreateUserCommand> validator)
        {
            _repository = genericRepository;
            _validator = validator;
        }

        public async Task<ServiceDataResponse<UserDTO>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var user = new UserDTO
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
