using Application.Common.DTOs;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Comments.Queries
{
    public class GetAllCommentsQuery : IRequest <ServiceDataResponse<IEnumerable<CommentDTO>>>
    {
    }
}
