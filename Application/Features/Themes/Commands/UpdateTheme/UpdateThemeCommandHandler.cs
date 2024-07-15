using Application.Common.DTOs;
using Domain.Models;
using Application.Common.Exceptions;
using Domain.Helpers;
using MediatR;
using AutoMapper;
using Application.Interfaces;

namespace Application.Features.Themes.Commands.UpdateTheme
{
    public class UpdateThemeCommandHandler : IRequestHandler<UpdateThemeCommand, ServiceDataResponse<ThemeDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateThemeCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceDataResponse<ThemeDTO>> Handle(UpdateThemeCommand request, CancellationToken cancellationToken)
        {
            var serviceDataResponse = await _unitOfWork.Repository<Theme>().GetByIdAsync(request.Id);

            if (serviceDataResponse == null)
            {
                throw new NotFoundException("Theme");
            }

            var theme = serviceDataResponse.Data;

            theme.Name = request.Name;
            theme.Description = request.Description;
            theme.UpdatedAt = DateTime.UtcNow;

            var themeId = theme.Id;

            var themeDTO = _mapper.Map<ThemeDTO>(theme);

            await _unitOfWork.Repository<Theme>().UpdateAsync(themeId, theme);
            await _unitOfWork.Save(cancellationToken);

            return ServiceDataResponse<ThemeDTO>.Succeeded(themeDTO);
        }
    }
}
