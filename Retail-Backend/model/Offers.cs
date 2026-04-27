namespace Retail_Backend.model
{
    public class Offer
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public decimal DiscountPercentage { get; set; }

        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public string Description { get; set; }
    }
}
