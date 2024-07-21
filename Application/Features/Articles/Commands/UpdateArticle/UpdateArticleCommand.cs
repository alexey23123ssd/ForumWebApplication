using Application.Common.DTOs;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommand : IRequest<ServiceDataResponse<ArticleDTO>>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
