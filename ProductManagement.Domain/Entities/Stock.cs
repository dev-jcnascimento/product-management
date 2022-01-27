using ProductManagement.Domain.Entities.Base;
using ProductManagement.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ProductManagement.Domain.Entities
{
    public class Stock : EntityBase
    {
        [DataType(DataType.Date)]
        public DateTime Data { get; private set; }
        public int Value { get; private set; }
        public StatusStock Status { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid UserId { get; private set; }
        public Product Product { get; private set; }
        public User User { get; private set; }
        protected Stock()
        {
        }
        public Stock(Guid productId, int value, StatusStock status, Guid userId)
        {
            Data = DateTime.Now;
            ProductId = productId;
            Value = value;
            Status = status;
            UserId = userId;
        }
    }
}
