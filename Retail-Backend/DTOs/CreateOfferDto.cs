namespace Retail_Backend.DTOs
{
    public class CreateOfferDto
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Description { get; set; }
    }
}