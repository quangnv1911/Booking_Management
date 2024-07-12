namespace Group5_SE1730_BookingManagement.Models
{
    public class Inbox
    {
        public Inbox()
        {
            Messages = new HashSet<Message>();
        }
        public long Id { get; set; } // Using long for identity primary key
        public string? FirstUserId { get; set; }
        public string? SecondUserId { get; set; }

        // Navigation properties
        public virtual Guest? FirstUser { get; set; }
        public virtual Guest? SecondUser { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
