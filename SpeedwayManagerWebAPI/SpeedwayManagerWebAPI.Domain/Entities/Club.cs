using SpeedwayManagerWebAPI.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpeedwayManagerWebAPI.Domain.Entities
{
    public class Club: EntityBase
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string City { get; set; }
        public string ImageRelativePath { get; set; }

        [Range(0, 100)]
        public int Reputation { get; set; }
        public int AccountBalance { get; set; }
        public int UserId { get; set; }
        public int StadiumId { get; set; }
        public int? LeagueId { get; set; }
        public int? ClubStaffId { get; set; }

        public virtual User User { get; set; }
        public virtual Stadium Stadium { get; set; }
        public virtual League League { get; set; }
        public virtual ClubStaff ClubStaff { get; set; }

        public virtual ICollection<Player> Players{ get; set; }
    }
}
