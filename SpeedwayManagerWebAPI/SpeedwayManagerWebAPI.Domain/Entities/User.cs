using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SpeedwayManagerWebAPI.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public int ClubId { get; set; }
        public virtual Club Club { get; set; }
    }
}