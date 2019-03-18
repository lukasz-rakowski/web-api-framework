using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Application.Exceptions
{
    public class UserNotFoundException: Exception
    {
        public UserNotFoundException():base("Użytkownik nie istnieje!")
        {

        }
    }
}
