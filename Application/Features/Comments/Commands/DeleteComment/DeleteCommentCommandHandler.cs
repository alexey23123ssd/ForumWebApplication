using Application.Common.DTOs;
using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using MediatR;

namespace Application.Features.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, ServiceResponse<CommentDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<CommentDTO>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var serviceResponse = await _unitOfWork.Repository<Comment>().GetByIdAsync(request.Id);
            if (serviceResponse == null)
            {
                throw new NotFoundException(nameof(serviceResponse));
            }

            var comment = serviceResponse.Data;
            var commentId = comment.Id;

            await _unitOfWork.Repository<Comment>().DeleteAsync(commentId);
            await _unitOfWork.Save(cancellationToken);

            return ServiceResponse<CommentDTO>.Succeeded();
        }
    }
}
