using Application.Common.DTOs;
using Application.Interfaces;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, ServiceDataResponse<CommentDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceDataResponse<CommentDTO>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new CommentDTO()
            {
                Content = request.Content,
                CreatedAt = DateTime.UtcNow,
            };

            var articleId = request.ArticleId;

            await _unitOfWork.commentRepository.CreateCommentAsync(articleId, comment);
            await _unitOfWork.Save(cancellationToken);

            return ServiceDataResponse<CommentDTO>.Succeeded(comment);
        }
    }
}
