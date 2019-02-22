using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SpeedwayManagerWebAPI.Application.Exceptions;
using AppUser = SpeedwayManagerWebAPI.Domain.Entities.User;

namespace SpeedwayManagerWebAPI.Application.User.Registration
{
    public class RegistrationRequestHandler : IRequestHandler<RegistrationRequest, RegistrationResponse>
    {
        private readonly SignInManager<AppUser> _userService;
        private readonly IMediator _mediator;

        public RegistrationRequestHandler(SignInManager<AppUser> userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
        }

        public async Task<RegistrationResponse> Handle(RegistrationRequest request, CancellationToken cancellationToken)
        {
            if (_userService.UserManager.FindByEmailAsync(request.Email) != null)
            {
                throw new EmailAddresIsAlreadyUsedException();
            }
            if (_userService.UserManager.FindByNameAsync(request.UserName) != null)
            {
                throw new LoginIsAlreadyUsedException();
            }
            AppUser user = new AppUser()
            {
                UserName = request.UserName,
                Email = request.Email
            };


            var creationResult = await _userService.UserManager.CreateAsync(user);

            if (creationResult.Succeeded)
            {

            }
            else
            {
                creationResult.
            }

                return null;
        }
    }
}
