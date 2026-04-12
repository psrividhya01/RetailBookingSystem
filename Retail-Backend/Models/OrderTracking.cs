namespace Retail_Backend.Models
{
    public class OrderTracking
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string Status { get; set; } // "Placed", "Confirmed", "Preparing", "OutForDelivery", "Delivered"
        public string Note { get; set; }   // e.g. "Your order is being packed"
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}