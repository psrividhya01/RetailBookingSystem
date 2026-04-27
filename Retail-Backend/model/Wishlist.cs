namespace Retail_Backend.model
{
    public class Wishlist
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<WishlistItem> WishlistItems { get; set; }
    }
}
