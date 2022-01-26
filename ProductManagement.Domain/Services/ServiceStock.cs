using ProductManagement.Domain.Arguments.Base;
using ProductManagement.Domain.Arguments.Stock;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Enum;
using ProductManagement.Domain.Interface.IRepositories;
using ProductManagement.Domain.Interface.IServices;

namespace ProductManagement.Domain.Services
{
    public class ServiceStock : IServiceStock
    {
        private readonly IRepositoryStock _repositoryStock;
        private readonly IRepositoryProduct _repositoryProduct;
        private readonly IRepositoryUser _repositoryUser;

        public ServiceStock(IRepositoryStock repositoryStock, IRepositoryProduct repositoryProduct, IRepositoryUser repositoryUser)
        {
            _repositoryStock = repositoryStock;
            _repositoryProduct = repositoryProduct;
            _repositoryUser = repositoryUser;
        }
        public CreateStockResponse InStock(CreateStockRequest request)
        {
            var user = _repositoryUser.GetById(request.UserId);
            var product = _repositoryProduct.GetById(request.ProductId);

            if (user == null || product == null) return null;

            var stock = new Stock(request.ProductId, request.Value, StatusStock.Entrada, request.UserId);
            var response = _repositoryStock.Create(stock);
            _repositoryStock.Save();

            return (CreateStockResponse)response;
        }
        public CreateStockResponse OutStock(CreateStockRequest request)
        {
            var user = _repositoryUser.GetById(request.UserId);
            var product = _repositoryProduct.GetById(request.ProductId);

            if (user == null || product == null) return null;

            int stockProduct = _repositoryStock.GetStockProduct(request.ProductId);
            stockProduct -= request.Value;

            if (stockProduct < 0) return new CreateStockResponse();

            var stock = new Stock(request.ProductId, request.Value, StatusStock.Saida, request.UserId);
            var response = _repositoryStock.Create(stock);
            _repositoryStock.Save();

            return (CreateStockResponse)response;
        }

        public ResponseBase Delete(Guid id)
        {
            var product = _repositoryStock.GetById(id);

            if (product == null) return null;

            _repositoryStock.Delete(product);
            _repositoryStock.Save();

            return new ResponseBase();
        }

        public StockResponse GetById(Guid id)
        {
            var product = _repositoryStock.GetById(id);

            if (product == null) return null;

            return (StockResponse)product;
        }

        public StockProductResponse GetStockProduct(Guid id)
        {
            int stockProduct = _repositoryStock.GetStockProduct(id);
            var product = _repositoryProduct.GetById(id);

            if (product == null) return null;

            StockProductResponse stockProductResponse = new();
            stockProductResponse.Dados(product.Name, stockProduct);

            return stockProductResponse;
        }

        public IEnumerable<StockResponse> ListAll()
        {
            return _repositoryStock.List().ToList().Select(x => (StockResponse)x).ToList();
        }

        public IEnumerable<StockResponse> ListIn()
        {
            return _repositoryStock.List().Where(x => x.Status == Enum.StatusStock.Entrada).ToList().Select(x => (StockResponse)x).ToList();
        }

        public IEnumerable<StockResponse> ListOut()
        {
            return _repositoryStock.List().Where(x => x.Status == Enum.StatusStock.Saida).ToList().Select(x => (StockResponse)x).ToList();
        }

        public IEnumerable<StockResponse> ListByProduct(Guid id)
        {
            var product = _repositoryProduct.GetById(id);
            if (product == null) return null;
            
            return _repositoryStock.List().Where(x => x.ProductId == id).ToList().Select(x => (StockResponse)x).ToList();
        }

        public IEnumerable<StockResponse> ListByUser(Guid id)
        {
            var user = _repositoryUser.GetById(id);
            if (user == null) return null;

            return _repositoryStock.List().Where(x => x.UserId == id).ToList().Select(x => (StockResponse)x).ToList();
        }

    }
}
