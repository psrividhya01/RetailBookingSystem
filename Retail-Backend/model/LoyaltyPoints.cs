namespace Retail_Backend.model
{
    public class LoyaltyPoints
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int Points { get; set; }
    }
}
