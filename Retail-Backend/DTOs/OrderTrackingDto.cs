namespace Retail_Backend.DTOs
{
    public class OrderTrackingDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}