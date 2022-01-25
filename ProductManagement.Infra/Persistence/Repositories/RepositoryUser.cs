using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interface.IRepositories;
using ProductManagement.Infra.Persistence.Repositories.Base;

namespace ProductManagement.Infra.Persistence.Repositories
{
    public class RepositoryUser : RepositoryBase<User, Guid>, IRepositoryUser
    {
        protected readonly ProductManagementContext _productManagementContext;
        public RepositoryUser(ProductManagementContext context) : base(context)
        {
            _productManagementContext = context;
        }


    }
}
