using MediatR;
using SpeedwayManagerWebAPI.Common.Enums;

namespace SpeedwayManagerWebAPI.Application.User.Registration
{
    public class RegistrationRequest: IRequest<RegistrationResponse>
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string ClubName { get; set; }
        public string ClubShortName { get; set; }
        public string ClubCity { get; set; }


        public string StadiumName { get; set; }
        public SurfaceType SufraceType { get; set; }
    }
}
