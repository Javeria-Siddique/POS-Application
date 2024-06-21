namespace POSApp.Entities
{
    public class Purchase (int productId, string productName, int quantity, decimal price)
    {
        public int productId { get; set; } = productId;
        public string productName { get; set; } = productName;
        public int quantity { get; set; } = quantity;
        public decimal price { get; set; } = price;
    }
}