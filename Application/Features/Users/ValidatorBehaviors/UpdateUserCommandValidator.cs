using Application.Features.Users.Commands.UpdateUser;
using FluentValidation;

namespace Application.Features.Users.ValidatorBehaviors
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(user => user.Name)
              .NotEmpty().WithMessage("Name is required")
              .Length(2, 20).WithMessage("Name must been between 2 and 20 characters");
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email address")
                .Length(8, 30).WithMessage("Email must be between 8 and 30 characters");
            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Passwoed is required")
                .Length(8, 20).WithMessage("Password must be between 8 and 20 characters");
        }
    }
}
