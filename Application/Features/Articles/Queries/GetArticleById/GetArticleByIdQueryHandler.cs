using Application.Common.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using MediatR;

namespace Application.Features.Articles.Queries.GetArticleById
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, ServiceDataResponse<ArticleDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetArticleByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceDataResponse<ArticleDTO>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Repository<Article>().GetByIdAsync(request.Id);
            var entity = result.Data;

            var articleDTO = _mapper.Map<ArticleDTO>(entity);

            return ServiceDataResponse<ArticleDTO>.Succeeded(articleDTO);
        }
    }
}
