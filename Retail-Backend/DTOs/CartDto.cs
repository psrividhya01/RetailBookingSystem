namespace Retail_Backend.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }
        public List<CartItemDto> Items { get; set; }
        public decimal GrandTotal { get; set; }
    }
}