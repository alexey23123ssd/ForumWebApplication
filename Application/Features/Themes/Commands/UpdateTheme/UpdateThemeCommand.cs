using Application.Common.DTOs;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Themes.Commands.UpdateTheme
{
    public class UpdateThemeCommand : IRequest<ServiceDataResponse<ThemeDTO>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
