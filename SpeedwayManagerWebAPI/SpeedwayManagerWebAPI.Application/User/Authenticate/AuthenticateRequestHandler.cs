using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SpeedwayManagerWebAPI.Application.Exceptions;
using SpeedwayManagerWebAPI.Common.Settings;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppUser = SpeedwayManagerWebAPI.Domain.Entities.User;

namespace SpeedwayManagerWebAPI.Application.User.Authenticate
{
    public class AuthenticateRequestHandler : IRequestHandler<AuthenticateRequest, AuthenticateResponse>
    {
        private readonly SignInManager<AppUser> _userService;
        private readonly AppSettings _appSettings;

        public AuthenticateRequestHandler(SignInManager<AppUser> userService, AppSettings appSettings)
        {
            _userService = userService;
            _appSettings = appSettings;
        }

        public async Task<AuthenticateResponse> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
        {
            AppUser user = null;
            if (request.UserName.Contains('@'))
                user = await _userService.UserManager.FindByEmailAsync(request.UserName);
            else
                user = await _userService.UserManager.FindByNameAsync(request.UserName);
            
            if (user == null)
                throw new UserNotFoundException();
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var expireIn = DateTimeOffset.UtcNow.AddMonths(2).UtcDateTime;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = expireIn,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticateResponse()
            {
                ExpiredIn = expireIn,
                Token = tokenHandler.WriteToken(token),
                UserId = user.Id,
                UserName = user.UserName
            };
        }
    }
}
