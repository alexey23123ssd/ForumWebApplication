using Application.Features.Comments.Commands.UpdateComment;
using FluentValidation;

namespace Application.Features.ValidatorBehaviors
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator()
        {
            RuleFor(comment => comment.Content)
                .NotEmpty().WithMessage("Content is required")
                .Length(5, 50).WithMessage("Content must been between 5 and 50 characters");
        }
    }
}
