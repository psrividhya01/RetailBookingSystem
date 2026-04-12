namespace Retail_Backend.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string PaymentMethod { get; set; } // "GPay", "CashOnDelivery"
        public string PaymentStatus { get; set; } // "Pending", "Success", "Failed"
        public string TransactionId { get; set; }
        public DateTime PaidAt { get; set; }
    }
}