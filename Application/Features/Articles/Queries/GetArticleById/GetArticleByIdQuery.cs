using Application.Common.DTOs;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Articles.Queries.GetArticleById
{
    public class GetArticleByIdQuery : IRequest<ServiceDataResponse<ArticleDTO>>
    {
        public Guid Id { get; set; }
    }
}
