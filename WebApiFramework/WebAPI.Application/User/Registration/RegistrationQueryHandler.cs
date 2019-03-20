using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebAPI.Application.Exceptions;
using AppUser = WebAPI.Domain.Entities.User;

namespace WebAPI.Application.User.Registration
{
    public class RegistrationQueryHandler : IRequestHandler<RegistrationQuery, RegistrationResponse>
    {
        private readonly SignInManager<AppUser> _userService;
        private readonly IMediator _mediator;

        public RegistrationQueryHandler(SignInManager<AppUser> userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
        }

        public async Task<RegistrationResponse> Handle(RegistrationQuery request, CancellationToken cancellationToken)
        {
            if (UserExistsByEmail(request))
            {
                throw new EmailAddresIsAlreadyUsedException();
            }
            if (UserExistsByUserName(request))
            {
                throw new LoginIsAlreadyUsedException();
            }

            var creationResult = await CreateUser(request);

            return await Authenticate(request, creationResult);
        }

        private async Task<RegistrationResponse> Authenticate(RegistrationQuery request, IdentityResult creationResult)
        {
            if (creationResult.Succeeded)
            {
                Authenticate.AuthenticateQuery authenticateRequest = new Authenticate.AuthenticateQuery()
                {
                    Password = request.Password,
                    UserName = request.UserName
                };

                var authenticateResult = await _mediator.Send(authenticateRequest);

                return new RegistrationResponse()
                {
                    ExpiredIn = authenticateResult.ExpiredIn,
                    Token = authenticateResult.Token,
                    UserId = authenticateResult.UserId,
                    UserName = authenticateResult.UserName
                };
            }
            else
            {
                throw new CannotCreateUserException(creationResult.Errors.FirstOrDefault()?.Description);
            }
        }

        private async Task<IdentityResult> CreateUser(RegistrationQuery request)
        {
            AppUser user = new AppUser()
            {
                UserName = request.UserName,
                Email = request.Email
            };

            HashPassword(request, user);

            var creationResult = await _userService.UserManager.CreateAsync(user);
            return creationResult;
        }

        private void HashPassword(RegistrationQuery request, AppUser user)
        {
            var passwordHash = _userService.UserManager.PasswordHasher.HashPassword(user, request.Password);
            user.PasswordHash = passwordHash;
        }

        private bool UserExistsByUserName(RegistrationQuery request)
        {
            return _userService.UserManager.Users.SingleOrDefault(x => x.UserName == request.UserName) != null;
        }

        private bool UserExistsByEmail(RegistrationQuery request)
        {
            return _userService.UserManager.Users.SingleOrDefault(x=>x.Email == request.Email) != null;
        }
    }
}
