using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Application.Exceptions
{
    public class RequestValidationException : Exception
    {
        public RequestValidationException(string message) : base(message)
        {
        }
    }

    public static class RequestValidationExceptionHelper
    {
        public static RequestValidationException CreateRequestValidationException(IList<FluentValidation.Results.ValidationFailure> exceptions)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var e in exceptions)
            {
                stringBuilder.AppendLine(e.ErrorMessage);
            }

            return new RequestValidationException(stringBuilder.ToString());
        }
    }
}
