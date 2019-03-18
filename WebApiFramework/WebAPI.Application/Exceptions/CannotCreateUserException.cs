using System;

namespace WebAPI.Application.Exceptions
{
    public class CannotCreateUserException : Exception
    {
        public CannotCreateUserException(string message) : base(message)
        {

        }
    }
}
