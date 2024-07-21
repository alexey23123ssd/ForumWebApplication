using Application.Common.DTOs;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<ServiceDataResponse<CommentDTO>>
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid ArticleId { get; set; }
    }
}
