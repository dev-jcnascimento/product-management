namespace ProductManagement.Domain.Arguments.Stock
{
    public class CreateStockRequest
    {
        public int Value { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
    }
}
