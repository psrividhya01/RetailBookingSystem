namespace Retail_Backend.DTOs
{
    public class AddTrackingDto
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    }
}