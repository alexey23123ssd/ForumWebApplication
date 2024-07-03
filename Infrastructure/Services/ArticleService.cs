using AutoMapper;
using Domain.Helpers;
using Domain.Interfaces.Repositiries;
using Domain.Models;
using ForumWebApplication.DTOs;
using Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class ArticleService : IGenericRepository<ArticleDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ArticleService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }
        public async Task<ServiceDataResponse<ArticleDTO>> CreateAsync(ArticleDTO entity)
        {
            if (entity == null)
            {
                return ServiceDataResponse<ArticleDTO>.Failed("Entity cannot be null");
            }


            var articleId = Guid.NewGuid();
            var article = _mapper.Map<Article>(entity);
            article.Id = articleId;


            _dbContext.Articles.Add(article);
            await _dbContext.SaveChangesAsync();

            return ServiceDataResponse<ArticleDTO>.Succeeded(entity);

        }

        public async Task<ServiceResponse<ArticleDTO>> DeleteAsync(Guid id)
        {
            var user = await _dbContext.Articles.SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return ServiceResponse<ArticleDTO>.Failed("Article doesnt exist");
            }

            _dbContext.Articles.Remove(user);
            await _dbContext.SaveChangesAsync();

            return ServiceResponse<ArticleDTO>.Succeeded();
        }

        public async Task<ServiceDataResponse<IEnumerable<ArticleDTO>>> GetAllAsync()
        {
            var articles = await _dbContext.Articles.ToListAsync();

            if (articles == null)
            {
                return ServiceDataResponse<IEnumerable<ArticleDTO>>.Failed("Articles doesnt exist");
            }

            var articlesDTO = _mapper.Map<IEnumerable<ArticleDTO>>(articles);

            return ServiceDataResponse<IEnumerable<ArticleDTO>>.Succeeded(articlesDTO);
        }

        public async Task<ServiceDataResponse<ArticleDTO>> GetByIdAsync(Guid id)
        {
            var article = await _dbContext.Articles.SingleOrDefaultAsync(u => u.Id == id);

            if (article == null)
            {
                return ServiceDataResponse<ArticleDTO>.Failed("Article with this id doesnt exist");
            }

            var articleDTO = _mapper.Map<ArticleDTO>(article);

            return ServiceDataResponse<ArticleDTO>.Succeeded(articleDTO);
        }

        public async Task<ServiceDataResponse<ArticleDTO>> UpdateAsync(ArticleDTO entity)
        {
            var article = await _dbContext.Articles.FirstOrDefaultAsync(u => u.Id == entity.Id);

            if (article == null)
            {
                return ServiceDataResponse<ArticleDTO>.Failed("Article doesnt exist");
            }

            _dbContext.Articles.Update(article);

            await _dbContext.SaveChangesAsync();

            var articleDTO = _mapper.Map<ArticleDTO>(article);

            return ServiceDataResponse<ArticleDTO>.Succeeded(articleDTO);
        }
    }
}
