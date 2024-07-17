using Group5_SE1730_BookingManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Group5_SE1730_BookingManagement.Repositories.Impl
{
    public class InboxRepo : IInboxRepo
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;

        public InboxRepo(Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }

        public void CreateNewChat(Inbox inbox) {
            _context.Inboxes.Add(inbox);
        }

        public Inbox? GetInboxByFromAndTo(string? userFrom, string? userTo)
        {
            return _context.Inboxes.FirstOrDefault(i => i.FirstUserId == userFrom && i.SecondUserId == userTo);
        }

        public Inbox? GetInboxById(long? id)
        {
            return _context.Inboxes.FirstOrDefault(i => i.Id == id);
        }

        public List<Inbox> GetInboxListByGuestId(string? id)
        {
            return _context.Inboxes.Include(g => g.FirstUser).Include(g => g.SecondUser).Where(i => i.FirstUserId == id || i.SecondUserId == id).ToList();
        }
    }
}
