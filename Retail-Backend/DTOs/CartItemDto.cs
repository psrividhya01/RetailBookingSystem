namespace Retail_Backend.DTOs
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public int Quantity { get; set; }
        public decimal ItemTotal { get; set; } // DiscountPrice * Quantity
    }
}