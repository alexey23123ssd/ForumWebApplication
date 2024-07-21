using Application.Common.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using MediatR;

namespace Application.Features.Comments.Queries
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, ServiceDataResponse<CommentDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCommentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceDataResponse<CommentDTO>> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Repository<Comment>().GetByIdAsync(request.Id);
            var entity = result.Data;

            var comment = _mapper.Map<CommentDTO>(entity);

            return ServiceDataResponse<CommentDTO>.Succeeded(comment);
        }
    }
}
