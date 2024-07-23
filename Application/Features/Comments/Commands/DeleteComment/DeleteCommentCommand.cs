using Application.Common.DTOs;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest<ServiceResponse<CommentDTO>>
    {
        public Guid Id { get; set; }

        public DeleteCommentCommand(Guid id)
        {
            Id = id;
        }
    }
}
