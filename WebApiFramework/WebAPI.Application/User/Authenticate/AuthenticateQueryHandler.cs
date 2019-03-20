using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Application.Exceptions;
using WebAPI.Common.Settings;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppUser = WebAPI.Domain.Entities.User;

namespace WebAPI.Application.User.Authenticate
{
    public class AuthenticateQueryHandler : IRequestHandler<AuthenticateQuery, AuthenticateResponse>
    {
        private readonly SignInManager<AppUser> _userService;
        private readonly IOptions<AppSettings> _appSettings;

        public AuthenticateQueryHandler(SignInManager<AppUser> userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings;
        }

        public async Task<AuthenticateResponse> Handle(AuthenticateQuery request, CancellationToken cancellationToken)
        {
            AppUser user = GetUser(request);

            await ValidatePassword(request, user);

            var tokenHandler = CreateToken(out var expireIn, out var token);

            return new AuthenticateResponse()
            {
                ExpiredIn = expireIn,
                Token = tokenHandler.WriteToken(token),
                UserId = user.Id,
                UserName = user.UserName
            };
        }

        private async Task ValidatePassword(AuthenticateQuery request, AppUser user)
        {
            var result = await _userService.UserManager.CheckPasswordAsync(user, request.Password);
            if (!result)
            {
                throw new IncorrectUserNameOrPasswordException();
            }
        }

        private JwtSecurityTokenHandler CreateToken(out DateTime expireIn, out SecurityToken token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Value.SecretKey);
            expireIn = DateTimeOffset.UtcNow.AddMonths(_appSettings.Value.TokenExpireMonths).UtcDateTime;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = expireIn,
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler;
        }

        private AppUser GetUser(AuthenticateQuery request)
        {
            AppUser user = null;
            if (request.UserName.Contains('@'))
                user = _userService.UserManager.Users.SingleOrDefault(x => x.Email == request.UserName);
            else
                user = _userService.UserManager.Users.SingleOrDefault(x => x.UserName == request.UserName);

            if (user == null)
                throw new IncorrectUserNameOrPasswordException();
            return user;
        }
    }
}
