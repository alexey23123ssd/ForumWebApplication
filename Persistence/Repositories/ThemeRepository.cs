using Application.Common.DTOs;
using Application.Interfaces.Repositiries;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ThemeRepository : IThemeRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IMapper _mapper;

        public ThemeRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public ThemeRepository(ApplicationDbContext dbcontext, IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = dbcontext;
        }
        public async Task<ServiceDataResponse<ThemeDTO>> CreateThemeAsync(Guid id, ThemeDTO themeDTO)
        {
            if(id == Guid.Empty) 
            { 
                throw new ArgumentNullException("User doesnt exist"); 
            }

            if(themeDTO == null)
            {
                return ServiceDataResponse<ThemeDTO>.Failed("Theme cannot be null");
            }

            var themeId = Guid.NewGuid();

            var theme = _mapper.Map<Theme>(themeDTO);
            theme.Id = themeId;
            theme.UserId = id;

            await _dbcontext.Themes.AddAsync(theme);
            return  ServiceDataResponse<ThemeDTO>.Succeeded(themeDTO);
        }
    }
}
