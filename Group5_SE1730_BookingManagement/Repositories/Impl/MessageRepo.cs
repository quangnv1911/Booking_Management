using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Repositories.Impl
{
    public class MessageRepo : IMessageRepo
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;

        public MessageRepo(Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }

        public void CreateMessage(Message message)
        {
            _context.Messages.Add(message); 
            _context.SaveChanges();
        }

        public List<Message> GetMessagesByInboxId(long inboxId)
        {
            return _context.Messages.Where(m => m.InboxId == inboxId).ToList();
        }
    }
}
