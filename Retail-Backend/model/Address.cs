namespace Retail_Backend.model
{
    public class Address
    {
        public int Id { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public int UserId { get; set; }   // FK
        public User User { get; set; }    // Navigation
    }
}
