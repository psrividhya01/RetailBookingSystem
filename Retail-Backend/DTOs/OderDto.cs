namespace Retail_Backend.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public string DeliveryStatus { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalPrice { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime? EstimatedDeliveryTime { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}