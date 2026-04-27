namespace Retail_Backend.DTOs
{
    public class UpdateMenuItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public string ImageUrl { get; set; }
        public bool IsVeg { get; set; }
        public bool IsAvailable { get; set; }
        public int StockQuantity { get; set; }
        public int PreparationTime { get; set; }
        public string Tags { get; set; }
    }
}