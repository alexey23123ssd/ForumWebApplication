using Application.Features.Themes.Commands.UpdateTheme;
using FluentValidation;

namespace Application.Features.Users.ValidatorBehaviors
{
    public class UpdateThemeCommandValidator : AbstractValidator<UpdateThemeCommand>
    {
        public UpdateThemeCommandValidator()
        {
            RuleFor(theme => theme.Name)
              .NotEmpty().WithMessage("Name is required")
              .Length(2, 20).WithMessage("Name must been between 2 and 20 characters");
            RuleFor(theme => theme.Description)
                .NotEmpty().WithMessage("Description is required")
                .Length(5, 50).WithMessage("Description must be between 5 and 50 characters");
        }
    }
}
