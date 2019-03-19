using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities.Base;

namespace WebAPI.Persistence.Configuration
{
    public class EntityBaseWithHistoryConfiguration<T> : EntityBaseConfiguration<T> where T: EntityBaseWithHistory
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Ignore(x => x.UserId).Ignore(x => x.User).Property(x => x.UserId).HasDefaultValueSql("SESSION_CONTEXT(N'user_id')");
        }
    }
}
