using HotChocolate;
using System;

namespace Library.Infrastructure.ErrorFilters
{
    public class NotImplementedErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is not NotImplementedException exception)
            {
                return error;
            }

            return ErrorBuilder.New()
                .SetMessage(exception.Message)
                .SetCode("NotImplemented")
                .Build();
        }
    }
}
