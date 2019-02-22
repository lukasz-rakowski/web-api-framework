using System;

namespace SpeedwayManagerWebAPI.Application.Exceptions
{
    public class CannotCreateUserException : Exception
    {
        public CannotCreateUserException(string message) : base(message)
        {

        }
    }
}
