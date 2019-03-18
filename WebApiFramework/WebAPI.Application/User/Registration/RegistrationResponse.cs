using System;

namespace WebAPI.Application.User.Registration
{
    public class RegistrationResponse
    {
        public string Token { get; set; }
        public DateTimeOffset ExpiredIn { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
