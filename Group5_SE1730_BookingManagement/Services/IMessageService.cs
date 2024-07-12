using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Services
{
    public interface IMessageService
    {
        void CreateMessage(string? content, string? guestId, DateTime? createAt, long? inboxId);
        List<Message> GetMessagesByInboxId(long inboxId);
    }
}
