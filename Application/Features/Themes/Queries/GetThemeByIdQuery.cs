using Application.Common.DTOs;
using MediatR;
using Domain.Helpers;

namespace Application.Features.Themes.Queries
{
    public class GetThemeByIdQuery :IRequest<ServiceDataResponse<ThemeDTO>>
    {
        public Guid Id { get; set; }

        public GetThemeByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
