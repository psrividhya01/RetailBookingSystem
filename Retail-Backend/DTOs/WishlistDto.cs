namespace Retail_Backend.DTOs
{
    public class WishlistDto
    {
        public int Id { get; set; }
        public List<WishlistItemDto> Items { get; set; }
    }
}