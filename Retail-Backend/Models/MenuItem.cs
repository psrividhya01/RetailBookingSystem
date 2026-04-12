namespace Retail_Backend.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsVeg { get; set; }
        public bool IsAvailable { get; set; }
        public int StockQuantity { get; set; }
        public decimal Rating { get; set; } = 0;
        public int ReviewCount { get; set; } = 0;
        public int PreparationTime { get; set; } // in minutes
        public string Tags { get; set; } // e.g. "spicy,bestseller,new"

        // Navigation
        public List<Review> Reviews { get; set; }
    }
}