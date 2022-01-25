using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Infra.Persistence.Map
{
    public class MapProduct : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired().HasColumnType("varchar(30)");
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("varchar(200)");
            builder.Property(x => x.Model).HasColumnName("Model").HasColumnType("varchar(30)");
            builder.Property(x => x.Brand).HasColumnName("Brand").HasColumnType("varchar(30)");
        }
    }
}
