using Application.Common.DTOs;
using Application.Interfaces.Repositiries;
using Application.Common.Exceptions;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Themes.Commands.UpdateTheme
{
    public class UpdateThemeCommandHandler : IRequestHandler<UpdateThemeCommand, ServiceDataResponse<ThemeDTO>>
    {
        private readonly IGenericRepository<ThemeDTO> _repository;

        public UpdateThemeCommandHandler(IGenericRepository<ThemeDTO> repository)
        {
                _repository = repository;
        }
        public async Task<ServiceDataResponse<ThemeDTO>> Handle(UpdateThemeCommand request, CancellationToken cancellationToken)
        {
            var serviceDataResponse = await _repository.GetByIdAsync(request.Id);

            if (serviceDataResponse == null)
            {
                throw new NotFoundException("Theme");
            }

            var theme = serviceDataResponse.Data;

            theme.Name = request.Name;
            theme.Description = request.Description;
            theme.UpdatedAt = DateTime.UtcNow;

            return await _repository.UpdateAsync(theme);
        }
    }
}
