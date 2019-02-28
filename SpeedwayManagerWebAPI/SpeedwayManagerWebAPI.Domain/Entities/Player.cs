using SpeedwayManagerWebAPI.Domain.Entities.Base;

namespace SpeedwayManagerWebAPI.Domain.Entities
{
    public class Player: EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int ClubId { get; set; }
        public virtual Club Club { get; set; }
    }
}