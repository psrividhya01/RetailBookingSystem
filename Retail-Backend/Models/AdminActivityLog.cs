namespace Retail_Backend.Models
{
    public class AdminActivityLog
    {
        public int Id { get; set; }
        public string AdminId { get; set; }
        public User Admin { get; set; }   // references User where Role = "Admin"
        public string Action { get; set; }   // e.g. "DeletedUser", "UpdatedMenuItem"
        public string TargetEntity { get; set; } // e.g. "MenuItem", "Order"
        public int TargetId { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}