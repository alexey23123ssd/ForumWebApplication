using Application.Common.DTOs;
using Domain.Helpers;

namespace Application.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        Task<ServiceDataResponse<CommentDTO>> CreateArticleAsync(Guid id, CommentDTO commentDTO);
    }
}
