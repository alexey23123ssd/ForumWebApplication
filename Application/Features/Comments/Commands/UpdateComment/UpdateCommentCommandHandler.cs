using Application.Common.DTOs;
using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using MediatR;

namespace Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, ServiceDataResponse<CommentDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceDataResponse<CommentDTO>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var serviceResponse = await _unitOfWork.Repository<Comment>().GetByIdAsync(request.Id);
            if(serviceResponse == null)
            {
                throw new NotFoundException(nameof(serviceResponse));
            }

            var comment = serviceResponse.Data;

            comment.Content = request.Content;
            comment.UpdatedAt = DateTime.UtcNow;

            var commentId = comment.Id;

            var commentDTO = _mapper.Map<CommentDTO>(comment);

            await _unitOfWork.Repository<Comment>().UpdateAsync(commentId, comment);
            await _unitOfWork.Save(cancellationToken);

            return ServiceDataResponse<CommentDTO>.Succeeded(commentDTO);
        }
    }
}
    