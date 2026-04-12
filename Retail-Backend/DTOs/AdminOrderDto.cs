namespace Retail_Backend.DTOs
{
    public class AdminOrderDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public decimal FinalPrice { get; set; }
        public string Status { get; set; }
        public string DeliveryStatus { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}