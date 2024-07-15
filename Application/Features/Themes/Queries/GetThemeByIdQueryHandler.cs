using Application.Common.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using MediatR;

namespace Application.Features.Themes.Queries
{
    public class GetThemeByIdQueryHandler : IRequestHandler<GetThemeByIdQuery, ServiceDataResponse<ThemeDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetThemeByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceDataResponse<ThemeDTO>> Handle(GetThemeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Repository<Theme>().GetByIdAsync(request.Id);
            var entity = result.Data;

            var theme = _mapper.Map<ThemeDTO>(entity);

            return ServiceDataResponse<ThemeDTO>.Succeeded(theme);
        }
    }
}
