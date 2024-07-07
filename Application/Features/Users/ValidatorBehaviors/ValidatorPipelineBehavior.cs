using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Application.Features.Users.ValidatorBehaviors
{
    public class ValidatorPipelineBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest,TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidatorPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
             _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators.Any())
            {
                ValidationContext<TRequest> context = new ValidationContext<TRequest>(request);
                ValidationResult[] validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context,cancellationToken)));
                List<ValidationFailure> failures = validationResults
                    .SelectMany(result => result.Errors)
                    .Where(error =>error != null)
                    .ToList();
                if (failures.Any())
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
