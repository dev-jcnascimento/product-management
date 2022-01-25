using ProductManagement.Domain.Arguments.Base;
using ProductManagement.Domain.Arguments.Product;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interface.IRepositories;
using ProductManagement.Domain.Interface.IServices;

namespace ProductManagement.Domain.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IRepositoryProduct _repositoryProduct;

        public ServiceProduct(IRepositoryProduct repositoryProduct)
        {
            _repositoryProduct = repositoryProduct;
        }
        public CreateProductResponse Create(CreateProductRequest request)
        {
            var product = new Product(request.Name, request.Description, request.Brand, request.Model);
            var response = _repositoryProduct.Create(product);
            _repositoryProduct.Save();
            return (CreateProductResponse)response;
        }

        public ResponseBase Delete(Guid id)
        {
            var product = _repositoryProduct.GetById(id);
            if (product == null)
                return null;
            _repositoryProduct.Delete(product);
            _repositoryProduct.Save();
            return new ResponseBase();
        }

        public IEnumerable<ProductResponse> List()
        {
            return _repositoryProduct.List().ToList().Select(x => (ProductResponse)x).ToList();
        }

        public UpdateProductResponse Update(UpdateProductRequest request)
        {
            Product product = _repositoryProduct.GetById(request.Id);
            if (product == null) return null;

            product.UpdateProduct(request.Name, request.Description,request.Model,request.Brand);
            var response = _repositoryProduct.Update(product);
            _repositoryProduct.Save();
            return (UpdateProductResponse)response;
        }

        public ProductResponse GetById(Guid id)
        {
            var product = _repositoryProduct.GetById(id);
            if (product == null) return null;
            return (ProductResponse)product;
        }
    }
}

