namespace Retail_Backend.DTOs
{
    public class LoyaltyPointsDto
    {
        public int UserId { get; set; }
        public int Points { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}