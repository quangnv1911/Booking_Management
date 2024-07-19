using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Repositories
{
    public interface IInboxRepo
    {
        void CreateNewChat(Inbox inbox);
        List<Inbox> GetInboxListByGuestId(string? id);
        Inbox? GetInboxByFromAndTo(string? userFrom, string? userTo);

        Inbox? GetInboxById(long? id);
    }
}
