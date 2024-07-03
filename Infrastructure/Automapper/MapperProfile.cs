using AutoMapper;
using Domain.Models;
using ForumWebApplication.DTOs;

namespace Infrastructure.Automapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<CommentDTO, User>();
            CreateMap<User, CommentDTO>();
        }

    }
}
