using MediatR;
using Microsoft.AspNetCore.Http;
using SpeedwayManagerWebAPI.Common.Enums;

namespace SpeedwayManagerWebAPI.Application.Club.Create
{
    public class CreateClubRequest: IRequest<CreateClubResponse>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string City { get; set; }
        public int UserId { get; set; }
        public string StadiumName { get; set; }

        public IFormFile Image { get; set; }
        public int StadiumLengthInMeters { get; set; }
        public SurfaceType StadiumSurfaceType { get; set; }
    }
}
