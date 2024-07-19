using Group5_SE1730_BookingManagement.Repositories.Impl;
using Group5_SE1730_BookingManagement.Repositories;
using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Services.Impl
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepo _messageRepo;

        public MessageService(IMessageRepo mesageRepo)
        {
            _messageRepo = mesageRepo;
        }

        public void CreateMessage(string? content, string? guestId, DateTime? createAt, long? inboxId)
        {
            
            Message message = new Message();
            message.Content = content;
            message.GuestId = guestId;
            message.CreateAt = createAt;
            message.InboxId = inboxId;

            _messageRepo.CreateMessage(message);
        }

        public List<Message> GetMessagesByInboxId(long inboxId)
        {
            return _messageRepo.GetMessagesByInboxId(inboxId);
        }
    }
}
