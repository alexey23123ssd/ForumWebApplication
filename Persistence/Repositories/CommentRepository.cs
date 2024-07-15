using Application.Common.DTOs;
using Application.Interfaces.Repositiries;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IMapper _mapper;

        public CommentRepository(ApplicationDbContext dbcontext)
        {
             _dbcontext = dbcontext;
        }

        public CommentRepository(ApplicationDbContext dbcontext, IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = dbcontext;
        }

        public async Task<ServiceDataResponse<CommentDTO>> CreateArticleAsync(Guid id, CommentDTO commentDTO)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("Article doesnt exist");
            }

            if (commentDTO == null)
            {
                return ServiceDataResponse<CommentDTO>.Failed("Comment cannot be null");
            }

            var commentId = Guid.NewGuid();

            var comment = _mapper.Map<Comment>(commentDTO);
            comment.Id = commentId;
            comment.ArticleId = id;

            await _dbcontext.Comments.AddAsync(comment);
            return ServiceDataResponse<CommentDTO>.Succeeded(commentDTO);
        }
    }
}
