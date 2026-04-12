namespace Retail_Backend.Models
{
    public class LoyaltyPoints
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int Points { get; set; } = 0;
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}