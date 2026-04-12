namespace Retail_Backend.DTOs
{
    public class UpdatePaymentDto
    {
        public string PaymentStatus { get; set; }  // "Success" or "Failed"
        public string TransactionId { get; set; }
    }
}