using Application.Common.DTOs;
using Application.Interfaces.Repositiries;
using Domain.Helpers;
using MediatR;
using Application.Interfaces;

namespace Application.Features.Themes.Commands.CreateTheme
{
    public class CreateThemeCommandHandler : IRequestHandler<CreateThemeCommand, ServiceDataResponse<ThemeDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateThemeCommandHandler(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }

        public async Task<ServiceDataResponse<ThemeDTO>> Handle(CreateThemeCommand request, CancellationToken cancellationToken)
        {
            var theme = new ThemeDTO()
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow,
            };

            var userId = request.UserId;

            await _unitOfWork.themeRepository.CreateThemeAsync(userId,theme);
            await _unitOfWork.Save(cancellationToken);

            return ServiceDataResponse<ThemeDTO>.Succeeded(theme);
        }
    }
}
