using MediatR;
using SpeedwayManagerWebAPI.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Entities = SpeedwayManagerWebAPI.Domain.Entities;

namespace SpeedwayManagerWebAPI.Application.Club.Create
{
    public class CreateClubRequestHandler : IRequestHandler<CreateClubRequest, CreateClubResponse>
    {
        private readonly Context _context;
        private readonly IMediator _mediator;

        public CreateClubRequestHandler(Context context)
        {
            _context = context;
        }

        public async Task<CreateClubResponse> Handle(CreateClubRequest request, CancellationToken cancellationToken)
        {
            var league = _context.Leagues.Where(l => l.Clubs.Count < 8).FirstOrDefault(x => x.Level == _context.Leagues.Max(y => y.Level));

            if (league == null)
            {
                //TODO: create new league
            }

            var entity = new Entities.Club()
            {
                AccountBalance = 1000000,
                City = request.City,
                LeagueId = null,
                Name = request.Name,
                ShortName = request.ShortName,
                Reputation = 10,
                Stadium = new Entities.Stadium()
                {
                    Name = request.StadiumName,
                    Capacity = 500,
                    LengthInMeters = request.StadiumLengthInMeters,
                    LightingInLuxes = 0,
                    SurfaceType = (byte)request.StadiumSurfaceType
                },
                ClubStaff = new Entities.ClubStaff(),
                UserId = request.UserId
            };

            //TODO: entity.Players = _mediator.Send(new CreateTeamRequest());

            _context.Clubs.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            
            return new CreateClubResponse() { Id = entity.Id };
        }
    }
}
