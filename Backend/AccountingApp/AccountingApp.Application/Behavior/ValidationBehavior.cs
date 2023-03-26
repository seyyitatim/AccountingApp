using AccountingApp.Application.Messaging;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Behavior
{
    public class ValidationBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, ICommand<TResponse>
    {
        public readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var errorDictionary = validators.Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage,
                (propertyName, errorMessage) => new
                {
                    Key = propertyName,
                    Values = errorMessage.Distinct().ToArray()
                })
                .ToDictionary(x => x.Key, x => x.Values[0]);

            if (errorDictionary.Any())
            {
                var errors = errorDictionary.Select(s => new ValidationFailure
                {
                    PropertyName = s.Value,
                    ErrorCode = s.Key
                });

                throw new ValidationException(errors);
            }

            return await next();
        }
    }
}
