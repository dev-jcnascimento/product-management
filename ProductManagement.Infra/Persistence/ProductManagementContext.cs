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
            ////seta o schema default
            ////modelbuilder.hasdefaultschema("apoio");

            ////remove a pluralização dos nomes das tabelas
            //modelbuilder.Conventions.Remove<PluralizingTableNameConvention>();

            ////remove exclusão em cascata
            //modelbuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelbuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            ////setar para usar varchar ou invés de nvarchar
            //modelbuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            ////caso eu esqueça de informar o tamanho do campo ele irá colocar varchar de 100
            //modelbuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            ////mapeia as entidades
            ////modelbuilder.Configurations.Add(new PlayerMap());
            ////modelbuilder.configurations.add(new platformmap());

            //#region adiciona entidades mapeadas - automaticamente via assembly
            //modelbuilder.Configurations.AddFromAssembly(typeof(ProductManagementContext).Assembly);
            //#endregion

            //#region adiciona entidades mapeadas - automaticamente via namespace
            ////assembly.getexecutingassembly().gettypes()
            ////    .where(type => type.namespace == "socialgames.domain.entities.player")
            ////    .tolist()
            ////    .foreach(type =>
            ////    {
            ////        dynamic instance = activator.createinstance(type);
            ////        modelbuilder.configurations.add(instance);
            ////    });
            //#endregion

            base.OnModelCreating(modelbuilder);
        }
    }
}
