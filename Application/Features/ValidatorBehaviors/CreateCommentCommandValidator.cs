using Application.Features.Comments.Commands.CreateComment;
using FluentValidation;

namespace Application.Features.ValidatorBehaviors
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(comment => comment.Content)
                .NotEmpty().WithMessage("Content is required")
                .Length(5, 50).WithMessage("Content must been between 5 and 50 characters");
        }
    }
}
