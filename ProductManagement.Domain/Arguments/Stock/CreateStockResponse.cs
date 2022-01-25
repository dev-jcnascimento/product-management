using System.Globalization;

namespace ProductManagement.Domain.Arguments.Stock
{
    public class CreateStockResponse
    {
        public Guid Id { get; set; }
        public string Data { get; set; }
        public int Value { get; set; }
        public string Status { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }

        public static explicit operator CreateStockResponse(Entities.Stock entity)
        {

            return new CreateStockResponse()
            {
                Id = entity.Id,
                Data = entity.Data.ToString("dd-MM-yyyy h:mm tt", CultureInfo.InvariantCulture),
                Value = entity.Value,
                Status = entity.Status.ToString(),
                ProductId = entity.ProductId,
                UserId = entity.UserId
            };
        }
    }
}
