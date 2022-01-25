using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Infra.Persistence.Map
{
    public class MapStock : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stock");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId).IsRequired().HasColumnName("UserId");
            builder.Property(x => x.ProductId).IsRequired().HasColumnName("ProductId");
            builder.Property(x => x.Data).HasColumnName("Data").IsRequired();
            builder.Property(x => x.Status).HasColumnName("Status").HasConversion<string>();
            builder.HasOne(c => c.User).WithMany(c => c.UserStocks).HasForeignKey(c => c.UserId);
            builder.HasOne(c => c.Product).WithMany(c => c.ProductStocks).HasForeignKey(c => c.ProductId);
        }
    }
}
