using SpeedwayManagerWebAPI.Domain.Entities.Base;

namespace SpeedwayManagerWebAPI.Domain.Entities
{
    public class Stadium: EntityBase
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int LightingInLuxes { get; set; }
        public int LengthInMeters { get; set; }
        public byte SurfaceType { get; set; }

        public int ClubId { get; set; }
        public virtual Club Club { get; set; }
    }
}