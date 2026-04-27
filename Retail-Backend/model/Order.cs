namespace Retail_Backend.model
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int? OfferId { get; set; }       // nullable — discount may not apply
        public Offer Offer { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountAmount { get; set; } = 0;
        public decimal FinalPrice { get; set; }
        public string Status { get; set; } = "Placed"; // Placed, Confirmed, Cancelled
        public string DeliveryStatus { get; set; } = "Pending"; // Pending, Preparing, OutForDelivery, Delivered
        public string PaymentMethod { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? EstimatedDeliveryTime { get; set; }

        // Navigation
        public List<OrderItem> OrderItems { get; set; }
        public Payment Payment { get; set; }
        public List<OrderTracking> TrackingHistory { get; set; }
    }
}