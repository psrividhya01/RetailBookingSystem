using System.ComponentModel.DataAnnotations;

namespace Retail_Backend.model
{
    public class Payment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }

        public string TransactionId { get; set; }
    }
}
