namespace ProductManagement.Domain.Arguments.Stock
{
    public class StockProductResponse
    {
        public string NameProduct { get; set; }
        public int Stock { get; set; }

        public void Dados(string nameProduct, int stock)
        {
            NameProduct = nameProduct;
            Stock = stock;
        }

    }
}
