using Application.Common.DTOs;
using Application.Interfaces.Repositiries;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IMapper _mapper;

        public ArticleRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public ArticleRepository(ApplicationDbContext dbcontext, IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = dbcontext;
        }

        public async Task<ServiceDataResponse<ArticleDTO>> CreateArticleAsync(Guid id, ArticleDTO articleDTO)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("Theme doesnt exist");
            }

            if (articleDTO == null)
            {
                return ServiceDataResponse<ArticleDTO>.Failed("Article cannot be null");
            }

            var articleId = Guid.NewGuid();

            var article = _mapper.Map<Article>(articleDTO);
            article.Id = articleId;
            article.ThemeId = id;

            await _dbcontext.Articles.AddAsync(article);
            return ServiceDataResponse<ArticleDTO>.Succeeded(articleDTO);
        }
    }
}
