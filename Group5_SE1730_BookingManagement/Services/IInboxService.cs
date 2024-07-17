using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Services
{
    public interface IInboxService
    {
        void CreateNewChat(string? fromUserId, string toUserId);

        List<Inbox> GetInboxListByGuestId(string? id);
        Inbox? GetInboxByFromAndTo(string? userFrom, string? userTo);

        Inbox? GetInboxById(long? id);
    }
}
