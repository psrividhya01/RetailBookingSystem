namespace Retail_Backend.model
{
    public class EmailLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Status { get; set; } // "Sent", "Failed"
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}