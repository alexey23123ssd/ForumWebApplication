using Application.Common.DTOs;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Themes.Commands.DeleteTheme
{
    public class DeleteThemeCommand : IRequest<ServiceResponse<ThemeDTO>>
    {
        public Guid Id { get; set; }

        public DeleteThemeCommand(Guid id)
        {
            Id = id;
        }
    }
}
