using FluentValidation;
using HotChocolate;
using System.Collections.Generic;

namespace Library.Infrastructure.ErrorFilters
{
    public class ValidationErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is not ValidationException validationException)
            {
                return error;
            }

            var errors = new List<IError>();
            foreach (var err in validationException.Errors)
            {
                var newErr = ErrorBuilder.New()
                    .SetMessage(err.ErrorMessage)
                    .SetCode("Validation")
                    .Build();

                errors.Add(newErr);
            }

            return new AggregateError(errors);
        }
    }
}
