using ErrorOr;
using FluentValidation;
using MediatR;

namespace BuberDinner.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRquest, TResponse> :
        IPipelineBehavior<TRquest, TResponse>
            where TRquest : IRequest<TResponse>
            where TResponse : IErrorOr
    {
        private readonly IValidator<TRquest>? _validator;

        public ValidationBehaviour(IValidator<TRquest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRquest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            if (_validator is null)
            {
                return await next();
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
               return await next();
            }

            var errors = validationResult.Errors
                .ConvertAll(validationFailure => Error.Validation(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage));

            return (dynamic)errors;
        }
    }
}
