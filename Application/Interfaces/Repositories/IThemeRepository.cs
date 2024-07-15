using Application.Common.DTOs;
using Domain.Helpers;

namespace Application.Interfaces.Repositories
{
    public interface IThemeRepository
    {
        Task<ServiceDataResponse<ThemeDTO>> CreateThemeAsync(Guid id, ThemeDTO theme);
    }
}
