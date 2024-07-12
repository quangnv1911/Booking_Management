namespace Group5_SE1730_BookingManagement.Models
{
    public class Message
    {
        public long Id { get; set; } // Using long for identity primary key
        public string? GuestId { get; set; }
        public DateTime CreateAt { get; set; }
        public long InboxId { get; set; }
        public string Content { get; set; }

        // Navigation properties
        public virtual Guest? Guest { get; set; }
        public virtual Inbox? Inbox { get; set; }
    }
}
