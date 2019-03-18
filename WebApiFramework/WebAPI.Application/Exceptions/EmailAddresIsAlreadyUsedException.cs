using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Application.Exceptions
{
    public class EmailAddresIsAlreadyUsedException: Exception
    {
        public EmailAddresIsAlreadyUsedException():base("Podany adres email jest już używany!")
        {

        }
    }
}
