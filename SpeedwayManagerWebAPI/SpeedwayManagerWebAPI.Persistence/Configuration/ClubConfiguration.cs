using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedwayManagerWebAPI.Domain.Entities;

namespace SpeedwayManagerWebAPI.Persistence.Configuration
{
    public class ClubConfiguration : EntityBaseConfiguration<Club>
    {
        public override void Configure(EntityTypeBuilder<Club> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.User).WithOne(x => x.Club).HasForeignKey<User>(x => x.ClubId);
            builder.HasOne(x => x.Stadium).WithOne(x => x.Club).HasForeignKey<Stadium>(x => x.ClubId).IsRequired();
            builder.HasOne(x => x.League).WithMany(x => x.Clubs);
            builder.HasMany(x => x.Players).WithOne(x => x.Club).HasForeignKey(x => x.ClubId);
            builder.Property(x => x.City).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ShortName).HasMaxLength(3).IsRequired();
            builder.Property(x => x.AccountBalance).HasDefaultValue(5000000);
            builder.Property(x => x.Reputation).IsRequired();
        }
    }
}
