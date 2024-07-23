using Application.Common.DTOs;
using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using MediatR;

namespace Application.Features.Themes.Commands.DeleteTheme
{
    public class DeleteThemeCommandHandler : IRequestHandler<DeleteThemeCommand, ServiceResponse<ThemeDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteThemeCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<ThemeDTO>> Handle(DeleteThemeCommand request, CancellationToken cancellationToken)
        {
            var serviceResponse = await _unitOfWork.Repository<Theme>().GetByIdAsync(request.Id);
            if (serviceResponse == null)
            {
                throw new NotFoundException(nameof(serviceResponse));
            }

            var theme = serviceResponse.Data;
            var themeId = theme.Id;


            await _unitOfWork.Repository<Theme>().DeleteAsync(themeId);
            await _unitOfWork.Save(cancellationToken);

            return ServiceResponse<ThemeDTO>.Succeeded();
        }
    }
}
