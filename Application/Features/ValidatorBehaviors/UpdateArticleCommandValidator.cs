﻿using Application.Features.Articles.Commands.UpdateArticle;
using FluentValidation;

namespace Application.Features.ValidatorBehaviors
{
    public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
    {
        public UpdateArticleCommandValidator()
        {
            RuleFor(article => article.Title)
                .NotEmpty()
                .WithMessage("Title cannot be empty")
                .Length(5, 30)
                .WithMessage("Title length must be between 5 and 30 symbols");
            RuleFor(article => article.Content)
                .NotEmpty()
                .WithMessage("Article content cannot be empty")
                .Length(10, 300)
                .WithMessage("Content length must be between 10 and 300 symbols");

        }
    }
}
