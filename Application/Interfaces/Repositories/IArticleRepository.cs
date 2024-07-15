using Application.Common.DTOs;
using Domain.Helpers;

namespace Application.Interfaces.Repositories
{
    public interface IArticleRepository
    {
        Task<ServiceDataResponse<ArticleDTO>> CreateArticleAsync(Guid id, ArticleDTO articleDTO);
    }
}
