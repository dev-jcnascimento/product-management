using ProductManagement.Domain.Entities.Base;

namespace ProductManagement.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get;private set; }
        public string Description { get; private set; }
        public string Model { get; private set; }
        public string Brand { get; private set; }
        public ICollection<Stock> ProductStocks { get; set; }

        protected Product()
        {
        }
        public Product(string name, string description, string model, string brand)
        {
            ValidatingName(name);
            Description = description;
            Model = model;
            Brand = brand;
        }
        public void UpdateProduct(string name, string description, string model, string brand)
        {
            ValidatingName(name);
            Description = description;
            Model = model;
            Brand = brand;
        }
        private void ValidatingName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length > 30)
            {
                throw new Exception("Name cannot be empty and cannot be shorter than 30 characters.");
            }
            Name = name;
        }
    }
}
