using Application.Common.DTOs;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Articles.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest<ServiceDataResponse<ArticleDTO>>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid ThemeId { get; set; }
    }
}
