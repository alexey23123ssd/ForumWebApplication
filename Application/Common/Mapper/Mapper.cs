using AutoMapper;
using Domain.Helpers;
using Domain.Models;

namespace Application.Common.Mapper
{
    internal class Mapper : Profile
    {
        public Mapper() 
        {
            CreateMap<ServiceDataResponse<User>, User>();
            CreateMap<User,ServiceDataResponse<User>>();
        }
    }
}
