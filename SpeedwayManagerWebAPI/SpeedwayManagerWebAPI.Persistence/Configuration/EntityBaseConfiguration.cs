using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedwayManagerWebAPI.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedwayManagerWebAPI.Persistence.Configuration
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
