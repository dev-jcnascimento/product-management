using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interface.IRepositories;
using ProductManagement.Infra.Persistence.Repositories.Base;

namespace ProductManagement.Infra.Persistence.Repositories
{
    public class RepositoryProduct : RepositoryBase<Product, Guid>, IRepositoryProduct
    {
        protected readonly ProductManagementContext _productManagementContext;
        public RepositoryProduct(ProductManagementContext context) : base(context)
        {
            _productManagementContext = context;
        }

    }
}
