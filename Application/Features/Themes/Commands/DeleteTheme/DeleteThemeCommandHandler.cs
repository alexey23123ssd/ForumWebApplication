using Application.Common.DTOs;
using Application.Common.Exceptions;
using Application.Interfaces.Repositiries;
using Domain.Helpers;
using MediatR;

namespace Application.Features.Themes.Commands.DeleteTheme
{
    public class DeleteThemeCommandHandler : IRequestHandler<DeleteThemeCommand, ServiceResponse<ThemeDTO>>
    {
        private readonly IGenericRepository<ThemeDTO> _repository;

        public DeleteThemeCommandHandler(IGenericRepository<ThemeDTO> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse<ThemeDTO>> Handle(DeleteThemeCommand request, CancellationToken cancellationToken)
        {
            var serviceResponse = await _repository.GetByIdAsync(request.id);
            if (serviceResponse == null)
            {
                throw new NotFoundException(nameof(serviceResponse));
            }

            var theme = serviceResponse.Data;

            return await _repository.DeleteAsync(theme.Id);
        }
    }
}
