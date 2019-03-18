using MediatR;

namespace WebAPI.Application.User.Authenticate
{
    public class AuthenticateQuery: IRequest<AuthenticateResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
