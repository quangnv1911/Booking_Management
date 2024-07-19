using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Repositories
{
    public interface IMessageRepo
    {
        void CreateMessage(Message message);
        List<Message> GetMessagesByInboxId(long inboxId);
    }
}
