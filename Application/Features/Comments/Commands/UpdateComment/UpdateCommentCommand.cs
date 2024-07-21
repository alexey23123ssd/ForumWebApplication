using Application.Common.DTOs;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<ServiceDataResponse<CommentDTO>>
    {
        public Guid Id { get; set; }
        public  string Content { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
