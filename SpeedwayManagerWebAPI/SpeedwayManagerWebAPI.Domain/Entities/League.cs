using SpeedwayManagerWebAPI.Domain.Entities.Base;
using System.Collections.Generic;

namespace SpeedwayManagerWebAPI.Domain.Entities
{
    public class League: EntityBase
    {
        public int Level { get; set; }
        public int Group { get; set; }

        public virtual ICollection<Club> Clubs { get; set; }
    }
}