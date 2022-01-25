using ProductManagement.Domain.Arguments.Base;
using ProductManagement.Domain.Arguments.Product;

namespace ProductManagement.Domain.Interface.IServices
{
    public interface IServiceProduct
    {
        CreateProductResponse Create(CreateProductRequest request);
        UpdateProductResponse Update(UpdateProductRequest request);
        ProductResponse GetById(Guid id);
        IEnumerable<ProductResponse> List();
        ResponseBase Delete(Guid id);
    }
}
