using ProductManagement.Domain.Arguments.Stock;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interface.IRepositories.Base;

namespace ProductManagement.Domain.Interface.IRepositories
{
    public interface IRepositoryStock : IRepositoryBase<Stock, Guid>
    {
        public int GetStockProduct(Guid id);
    }
}
