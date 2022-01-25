namespace ProductManagement.Domain.Arguments.Product
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
    }
}
