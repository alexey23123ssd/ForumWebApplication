using Application.Common.DTOs;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Comments.Queries
{
    public class GetCommentByIdQuery : IRequest<ServiceDataResponse<CommentDTO>>
    {
        public Guid Id { get; set; }

        public GetCommentByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
