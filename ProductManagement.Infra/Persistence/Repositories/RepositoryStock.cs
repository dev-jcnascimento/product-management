using ProductManagement.Domain.Arguments.Stock;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Enum;
using ProductManagement.Domain.Interface.IRepositories;
using ProductManagement.Infra.Persistence.Repositories.Base;

namespace ProductManagement.Infra.Persistence.Repositories
{
    public class RepositoryStock : RepositoryBase<Stock, Guid>, IRepositoryStock
    {
        protected readonly ProductManagementContext _productManagementContext;
        public RepositoryStock(ProductManagementContext context) : base(context)
        {
            _productManagementContext = context;
        }
        public int GetStockProduct(Guid id)
        {
            var teste = _productManagementContext.Set<Stock>();
            IEnumerable<Stock> stockProduct = teste.Where(x => x.ProductId == id).ToList();
            int inStock = 0;
            int outStock = 0;
            foreach (Stock stock in stockProduct)
            {
                if (stock.Status == StatusStock.Entrada)
                {
                    inStock += stock.Value;
                }
                if (stock.Status == StatusStock.Saida)
                {
                    outStock += stock.Value;
                }
            }
            int total = inStock - outStock;
            return total;
        }
    }
}
