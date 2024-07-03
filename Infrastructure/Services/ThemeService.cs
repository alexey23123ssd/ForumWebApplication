using AutoMapper;
using Domain.Helpers;
using Domain.Interfaces.Repositiries;
using Domain.Models;
using ForumWebApplication.DTOs;
using Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public  class ThemeService : IGenericRepository<ThemeDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ThemeService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }
        public async Task<ServiceDataResponse<ThemeDTO>> CreateAsync(ThemeDTO entity)
        {
            if (entity == null)
            {
                return ServiceDataResponse<ThemeDTO>.Failed("Entity cannot be null");
            }

            var themeId = Guid.NewGuid();
            var theme = _mapper.Map<Theme>(entity);
            theme.Id = themeId;


            _dbContext.Themes.Add(theme);
            await _dbContext.SaveChangesAsync();

            return ServiceDataResponse<ThemeDTO>.Succeeded(entity);

        }

        public async Task<ServiceResponse<ThemeDTO>> DeleteAsync(Guid id)
        {
            var theme = await _dbContext.Themes.SingleOrDefaultAsync(u => u.Id == id);

            if (theme == null)
            {
                return ServiceResponse<ThemeDTO>.Failed("User doesnt exist");
            }

            _dbContext.Themes.Remove(theme);
            await _dbContext.SaveChangesAsync();

            return ServiceResponse<ThemeDTO>.Succeeded();
        }

        public Task<ServiceDataResponse<IEnumerable<ThemeDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceDataResponse<ThemeDTO>> GetByIdAsync(Guid id)
        {
            var theme = await _dbContext.Themes.SingleOrDefaultAsync(u => u.Id == id);

            if (theme == null)
            {
                return ServiceDataResponse<ThemeDTO>.Failed("User with this id doesnt exist");
            }

            var themeDTO = _mapper.Map<ThemeDTO>(theme);

            return ServiceDataResponse<ThemeDTO>.Succeeded(themeDTO);
        }

        public async Task<ServiceDataResponse<ThemeDTO>> UpdateAsync(ThemeDTO entity)
        {
            var theme = await _dbContext.Themes.FirstOrDefaultAsync(u => u.Id == entity.Id);

            if (theme == null)
            {
                return ServiceDataResponse<ThemeDTO>.Failed("User doesnt exist");
            }

            _dbContext.Themes.Update(theme);

            await _dbContext.SaveChangesAsync();

            var themeDTO = _mapper.Map<ThemeDTO>(theme);

            return ServiceDataResponse<ThemeDTO>.Succeeded(themeDTO);
        }
    }
}
