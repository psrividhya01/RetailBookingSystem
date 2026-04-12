using Microsoft.AspNetCore.Identity;

namespace Retail_Backend.Models
{
    public class User:IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; } = "Customer"; // "Customer" or "Admin"
        public bool IsEmailVerified { get; set; } = false;
        public string ProfileImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Cart Cart { get; set; }
        public Wishlist Wishlist { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Order> Orders { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Review> Reviews { get; set; }
        public LoyaltyPoints LoyaltyPoints { get; set; }
    }
}
