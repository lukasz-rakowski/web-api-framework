using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SpeedwayManagerWebAPI.Application.Club.Create;
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
            if (_userService.UserManager.Users.SingleOrDefault(x=>x.Email == request.Email) != null)
            {
                throw new EmailAddresIsAlreadyUsedException();
            }
            if (_userService.UserManager.Users.SingleOrDefault(x => x.UserName == request.UserName) != null)
            {
                throw new LoginIsAlreadyUsedException();
            }
            AppUser user = new AppUser()
            {
                UserName = request.UserName,
                Email = request.Email,
                ClubId = (await _mediator.Send(new CreateClubRequest()
                {
                    City = request.ClubCity,
                    Name = request.ClubName,
                    ShortName = request.ClubShortName,
                    StadiumName = request.StadiumName,
                    StadiumLengthInMeters = 360,
                    StadiumSurfaceType = Common.Enums.SurfaceType.Normal
                })).Id
            };

            _userService.UserManager.PasswordHasher.HashPassword(user, request.Password);

            var creationResult = await _userService.UserManager.CreateAsync(user);

            if (creationResult.Succeeded)
            {
                Authenticate.AuthenticateRequest authenticateRequest = new Authenticate.AuthenticateRequest()
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
    }
}
