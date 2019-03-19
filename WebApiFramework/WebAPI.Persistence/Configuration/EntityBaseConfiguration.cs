using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities.Base;

namespace WebAPI.Persistence.Configuration
{
    public class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.Timestamp).IsRowVersion();
        }
    }
}
