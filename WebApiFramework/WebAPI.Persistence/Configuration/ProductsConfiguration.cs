using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPI.Persistence.Configuration
{
    public class ProductsConfiguration : EntityBaseWithHistoryConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

        }
    }
}
