using AutoMapper;
using Domain.Helpers;
using Domain.Interfaces.Repositiries;
using Domain.Models;
using ForumWebApplication.DTOs;
using Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class CommentService : IGenericRepository<CommentDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CommentService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }
        public async Task<ServiceDataResponse<CommentDTO>> CreateAsync(CommentDTO entity)
        {
            if (entity == null)
            {
                return ServiceDataResponse<CommentDTO>.Failed("Entity cannot be null");
            }

            var commentId = Guid.NewGuid();
            var comment = _mapper.Map<Comment>(entity);
            comment.Id = commentId;


            _dbContext.Comments.Add(comment);
            await _dbContext.SaveChangesAsync();

            return ServiceDataResponse<CommentDTO>.Succeeded(entity);

        }

        public async Task<ServiceResponse<CommentDTO>> DeleteAsync(Guid id)
        {
            var comment = await _dbContext.Comments.SingleOrDefaultAsync(u => u.Id == id);

            if (comment == null)
            {
                return ServiceResponse<CommentDTO>.Failed("Comment doesnt exist");
            }

            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();

            return ServiceResponse<CommentDTO>.Succeeded();
        }

        public async Task<ServiceDataResponse<IEnumerable<CommentDTO>>> GetAllAsync()
        {
            var cooments = await _dbContext.Comments.ToListAsync();

            if (cooments == null)
            {
                return ServiceDataResponse<IEnumerable<CommentDTO>>.Failed("Comments doesnt exist");
            }

            var coomentsDTO = _mapper.Map<IEnumerable<CommentDTO>>(cooments);

            return ServiceDataResponse<IEnumerable<CommentDTO>>.Succeeded(coomentsDTO);
        }

        public async Task<ServiceDataResponse<CommentDTO>> GetByIdAsync(Guid id)
        {
            var comment = await _dbContext.Comments.SingleOrDefaultAsync(u => u.Id == id);

            if (comment == null)
            {
                return ServiceDataResponse<CommentDTO>.Failed("Comment with this id doesnt exist");
            }

            var commentDTO = _mapper.Map<CommentDTO>(comment);

            return ServiceDataResponse<CommentDTO>.Succeeded(commentDTO);
        }

        public async Task<ServiceDataResponse<CommentDTO>> UpdateAsync(CommentDTO entity)
        {
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == entity.Id);

            if (comment == null)
            {
                return ServiceDataResponse<CommentDTO>.Failed("Comment doesnt exist");
            }

            _dbContext.Comments.Update(comment);

            await _dbContext.SaveChangesAsync();

            var commentDTO = _mapper.Map<CommentDTO>(comment);

            return ServiceDataResponse<CommentDTO>.Succeeded(commentDTO);
        }
    }
}
