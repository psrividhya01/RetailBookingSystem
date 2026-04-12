namespace Retail_Backend.DTOs
{
    public class PlaceOrderDto
    {
        public int AddressId { get; set; }
        public string PaymentMethod { get; set; } // "GPay" or "CashOnDelivery"
        public int? OfferId { get; set; }
    }
}