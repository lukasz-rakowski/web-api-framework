using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedwayManagerWebAPI.Application.Exceptions
{
    public class EmailAddresIsAlreadyUsedException: Exception
    {
        public EmailAddresIsAlreadyUsedException():base("Podany adres email jest już używany!")
        {

        }
    }
}
