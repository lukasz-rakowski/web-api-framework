using MediatR;

namespace SpeedwayManagerWebAPI.Application.User.Authenticate
{
    public class AuthenticateRequest: IRequest<AuthenticateResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
