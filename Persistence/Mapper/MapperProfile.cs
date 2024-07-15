using Application.Common.DTOs;
using AutoMapper;
using Domain.Models;

namespace Persistence.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ThemeDTO, Theme>();
            CreateMap<Theme, ThemeDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<ArticleDTO, Article>();
            CreateMap<Article, ArticleDTO>();
            CreateMap<CommentDTO, Comment>();
            CreateMap<Comment, CommentDTO>();
        }
    }
}
