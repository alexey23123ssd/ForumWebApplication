using Application.Common.DTOs;
using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using MediatR;

namespace Application.Features.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, ServiceDataResponse<ArticleDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateArticleCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceDataResponse<ArticleDTO>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var serviceResponse = await _unitOfWork.Repository<Article>().GetByIdAsync(request.Id);
            if (serviceResponse == null)
            {
                throw new NotFoundException(nameof(serviceResponse));
            }

            var article = serviceResponse.Data;

            article.Title = request.Title;
            article.Content = request.Content;
            article.UpdatedAt = DateTime.UtcNow;

            var articleId = article.Id;

            var articleDTO = _mapper.Map<ArticleDTO>(article);

            await _unitOfWork.Repository<Article>().UpdateAsync(articleId, article);
            await _unitOfWork.Save(cancellationToken);

            return ServiceDataResponse<ArticleDTO>.Succeeded(articleDTO);
        }
    }
}
