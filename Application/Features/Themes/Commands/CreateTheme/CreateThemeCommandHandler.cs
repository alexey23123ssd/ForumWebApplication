using Application.Common.DTOs;
using Application.Interfaces.Repositiries;
using Domain.Helpers;
using MediatR;
using FluentValidation;

namespace Application.Features.Themes.Commands.CreateTheme
{
    public class CreateThemeCommandHandler : IRequestHandler<CreateThemeCommand, ServiceDataResponse<ThemeDTO>>
    {
        private readonly IGenericRepository<ThemeDTO> _repository;

        public CreateThemeCommandHandler(IGenericRepository<ThemeDTO> repository)
        {
           _repository = repository;
        }

        public async Task<ServiceDataResponse<ThemeDTO>> Handle(CreateThemeCommand request, CancellationToken cancellationToken)
        {
            var theme = new ThemeDTO()
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow,
            };

            return await _repository.CreateAsync(theme);
        }
    }
}
