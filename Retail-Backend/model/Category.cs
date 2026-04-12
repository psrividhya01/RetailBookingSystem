using System.ComponentModel.DataAnnotations;

namespace Retail_Backend.model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<MenuItem> MenuItems { get; set; }
    }
}
