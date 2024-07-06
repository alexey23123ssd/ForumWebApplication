using MediatR;

namespace Application.Features.Users.ValidatorBehaviors
{
    public class ValidatorPipelineBehavior : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
    {

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
