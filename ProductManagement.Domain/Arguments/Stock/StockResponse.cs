using ProductManagement.Domain.Arguments.Base;
using System.Globalization;

namespace ProductManagement.Domain.Arguments.Stock
{
    public class StockResponse
    {
        public Guid Id { get; set; }
        public string Data { get; set; }
        public int Value { get; set; }
        public string Status { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }

        public static explicit operator StockResponse(Entities.Stock entity)
        {
            return new StockResponse()
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
