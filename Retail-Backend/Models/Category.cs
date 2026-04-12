namespace Retail_Backend.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }  // small addition — useful for home page category icons
        public List<MenuItem> MenuItems { get; set; }
    }
}