using Application.Common.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using MediatR;
using System.Runtime.CompilerServices;

namespace Application.Features.Comments.Queries
{
    public class GetAllCommentsQueryHandler : IRequestHandler
        <GetAllCommentsQuery, ServiceDataResponse<IEnumerable<CommentDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCommentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceDataResponse<IEnumerable<CommentDTO>>> Handle(GetAllCommentsQuery request, 
            CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Repository<Comment>().GetAllAsync();

            var comments = result.Data;

            var commentsDTO = _mapper.Map<IEnumerable<CommentDTO>>(comments);

            return ServiceDataResponse<IEnumerable<CommentDTO>>.Succeeded(commentsDTO);
        }
    }
}
