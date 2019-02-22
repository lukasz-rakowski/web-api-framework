using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedwayManagerWebAPI.Application.Exceptions
{
    public class LoginIsAlreadyUsedException : Exception
    {
        public LoginIsAlreadyUsedException() : base("Podana nazwa użytkownika jest już zajęta!")
        {

        }
    }
}
