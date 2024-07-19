using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Repositories;
using Group5_SE1730_BookingManagement.Repositories.Impl;

namespace Group5_SE1730_BookingManagement.Services.Impl
{
    public class InboxService : IInboxService
    {
        private readonly IInboxRepo _inboxRepo;

        public InboxService(IInboxRepo inboxRepo)
        {
            _inboxRepo = inboxRepo;
        }
        public void CreateNewChat(string? firstUserId, string secondUserId)
        {
            Inbox inbox = new Inbox();
            inbox.FirstUserId = firstUserId;
            inbox.SecondUserId = secondUserId;
            _inboxRepo.CreateNewChat(inbox);
        }

        public Inbox? GetInboxByFromAndTo(string? userFrom, string? userTo)
        {
            return _inboxRepo.GetInboxByFromAndTo(userFrom, userTo);
        }

        public Inbox? GetInboxById(long? id)
        {
            return _inboxRepo.GetInboxById(id);
        }

        public List<Inbox> GetInboxListByGuestId(string? id)
        {
            return _inboxRepo.GetInboxListByGuestId(id);
        }
    }
}
