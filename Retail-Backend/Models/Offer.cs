namespace Retail_Backend.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }  // small addition — promo code like "SAVE20"
        public decimal DiscountPercentage { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}