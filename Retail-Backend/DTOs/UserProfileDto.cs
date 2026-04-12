namespace Retail_Backend.DTOs
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}