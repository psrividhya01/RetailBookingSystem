namespace Retail_Backend.DTOs
{
    public class OfferDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}