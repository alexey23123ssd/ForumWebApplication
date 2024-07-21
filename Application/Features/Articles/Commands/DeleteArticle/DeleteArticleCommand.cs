using Application.Common.DTOs;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Articles.Commands.DeleteArticle
{
    public class DeleteArticleCommand : IRequest<ServiceResponse<ArticleDTO>>
    {
        public Guid Id { get; set; }
    }
}
