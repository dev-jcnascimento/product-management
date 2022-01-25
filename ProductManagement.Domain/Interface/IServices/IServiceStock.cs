using ProductManagement.Domain.Arguments.Base;
using ProductManagement.Domain.Arguments.Stock;

namespace ProductManagement.Domain.Interface.IServices
{
    public interface IServiceStock
    {
        CreateStockResponse InStock(CreateStockRequest request);
        CreateStockResponse OutStock(CreateStockRequest request);
        StockResponse GetById(Guid id);
        StockProductResponse GetStockProduct(Guid id);
        IEnumerable<StockResponse> ListAll();
        IEnumerable<StockResponse> ListIn();
        IEnumerable<StockResponse> ListOut();
        IEnumerable<StockResponse> ListByProduct(Guid id);
        IEnumerable<StockResponse> ListByUser(Guid id);
        ResponseBase Delete(Guid id);
    }
}
