namespace Retail_Backend.model
{
    public class User
    {
        public int Id { get; set; }   // Primary Key

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
