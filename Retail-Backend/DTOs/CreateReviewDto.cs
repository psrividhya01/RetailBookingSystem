namespace Retail_Backend.DTOs
{
    public class CreateReviewDto
    {
        public int MenuItemId { get; set; }
        public int Rating { get; set; }  // 1 to 5
        public string Comment { get; set; }
    }
}