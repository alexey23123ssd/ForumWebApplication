using Application.Common.DTOs;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Themes.Commands.CreateTheme
{
    public class CreateThemeCommand : IRequest<ServiceDataResponse<ThemeDTO>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
    }
}
