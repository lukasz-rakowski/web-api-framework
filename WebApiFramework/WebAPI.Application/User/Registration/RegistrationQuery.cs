using MediatR;

namespace WebAPI.Application.User.Registration
{
    public class RegistrationQuery: IRequest<RegistrationResponse>
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
