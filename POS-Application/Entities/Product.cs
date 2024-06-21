namespace POSApp.Entities
{
	public class Product (int id, string name, decimal price, int quantity, string type, string category)
	{
		public int Id { get; set; } = id;
		public string name { get; set; } = name;
		public decimal price { get; set; } = price;
		public int quantity { get; set; } = quantity;
		public string type { get; set; } = type;
		public string category { get; set; } = category;
	}
}