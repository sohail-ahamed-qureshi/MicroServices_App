namespace Basket.API.Entities
{
    public class ShoppingCartItems
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal price { get; set; }
        public string productId { get; set; }
        public string ProductName { get; set; }
    }
}