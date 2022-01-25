using ProductManagement.Domain.Arguments.Base;

namespace ProductManagement.Domain.Arguments.Product
{
    public class UpdateProductResponse : ResponseBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }

        public static explicit operator UpdateProductResponse(Entities.Product entity)
        {
            return new UpdateProductResponse()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Model = entity.Model,
                Brand = entity.Brand
            };
        }
    }
}
