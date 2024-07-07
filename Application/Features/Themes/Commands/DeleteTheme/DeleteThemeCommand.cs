using Application.Common.DTOs;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Themes.Commands.DeleteTheme
{
    public class DeleteThemeCommand : IRequest<ServiceResponse<ThemeDTO>>
    {
        public Guid id { get; set; }
    }
}
