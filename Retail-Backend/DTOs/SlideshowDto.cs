namespace Retail_Backend.DTOs
{
    public class SlideshowDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string LinkUrl { get; set; }
        public int DisplayOrder { get; set; }
    }
}