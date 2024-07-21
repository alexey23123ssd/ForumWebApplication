using Application.Common.DTOs;
using Application.Interfaces;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, ServiceDataResponse<ArticleDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateArticleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceDataResponse<ArticleDTO>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = new ArticleDTO()
            {
                Title = request.Title,
                Content = request.Content,
                CreatedAt = DateTime.UtcNow
            };

            var themeId = request.ThemeId;
            await _unitOfWork.articleRepository.CreateArticleAsync(themeId, article);
            await _unitOfWork.Save(cancellationToken);

            return ServiceDataResponse<ArticleDTO>.Succeeded(article);
        }
    }
}
