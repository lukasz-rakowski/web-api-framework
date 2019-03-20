using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Application.Exceptions
{
    public class IncorrectUserNameOrPasswordException : Exception
    {
        public IncorrectUserNameOrPasswordException() : base("Zła nazwa użytkownika lub hasło!")
        {

        }
    }
}
