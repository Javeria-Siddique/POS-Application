namespace POSApp.Entities
{
    public class Sale (int id, int cashierId)
    {
        public int Id { get; set; } = id;
        public int cashierId { get; set; } = cashierId;
        public List<Purchase> Items { get; set; } = new List<Purchase>();
    }
}