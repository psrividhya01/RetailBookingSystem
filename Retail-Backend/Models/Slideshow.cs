namespace Retail_Backend.Models
{
    public class Slideshow
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string LinkUrl { get; set; }   // clicking banner goes to this URL/page
        public bool IsActive { get; set; } = true;
        public int DisplayOrder { get; set; } // controls the order of banners
    }
}