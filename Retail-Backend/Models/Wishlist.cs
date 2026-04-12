namespace Retail_Backend.Models
{
    public class Wishlist
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<WishlistItem> WishlistItems { get; set; }
    }
}