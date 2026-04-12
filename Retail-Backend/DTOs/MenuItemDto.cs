namespace Retail_Backend.DTOs
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsVeg { get; set; }
        public bool IsAvailable { get; set; }
        public int StockQuantity { get; set; }
        public decimal Rating { get; set; }
        public int ReviewCount { get; set; }
        public int PreparationTime { get; set; }
        public string Tags { get; set; }
    }
}