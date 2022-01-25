using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Infra.Persistence.Map
{
    public class MapUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(x => x.Webmail).HasColumnName("Email").IsRequired().HasColumnType("varchar(200)");
            });
            builder.OwnsOne(x => x.Nome, name =>
            {
                name.Property(x => x.FistName).HasColumnName("FistName").IsRequired().HasColumnType("varchar(50)");
                name.Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasColumnType("varchar(50)");
            });
            builder.OwnsOne(x => x.Password, password =>
            {
                password.Property(x => x.Word).HasColumnName("Password").IsRequired();
            });
            builder.Property(x => x.Role).HasColumnName("Role").HasConversion<string>();
        }
    }
}
