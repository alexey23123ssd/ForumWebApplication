using Application.Common.DTOs;
using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Numerics;

namespace Application.Features.Articles.Commands.DeleteArticle
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, ServiceResponse<ArticleDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteArticleCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<ArticleDTO>> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var serviceResponse = await _unitOfWork.Repository<ArticleDTO>().GetByIdAsync(request.Id);
            if(serviceResponse == null)
            {
                throw new NotFoundException(nameof(serviceResponse));
            }

            var article = serviceResponse.Data;
            var articleId = request.Id;

            await _unitOfWork.Repository<Article>().DeleteAsync(articleId);
            await _unitOfWork.Save(cancellationToken);

            return ServiceResponse<ArticleDTO>.Succeeded();

        }
    }
}
