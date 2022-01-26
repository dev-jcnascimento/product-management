using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Infra.Persistence.Map;

namespace ProductManagement.Infra.Persistence
{
    public class ProductManagementContext : DbContext
    {
        public ProductManagementContext(DbContextOptions<ProductManagementContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfiguration(new MapUser());
            modelbuilder.ApplyConfiguration(new MapProduct());
            modelbuilder.ApplyConfiguration(new MapStock());

            base.OnModelCreating(modelbuilder);
        }
    }
}
