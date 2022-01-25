using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interface.IRepositories.Base;

namespace ProductManagement.Domain.Interface.IRepositories
{
    public interface IRepositoryUser : IRepositoryBase<User, Guid>
    {
    }
}
