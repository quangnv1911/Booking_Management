namespace Group5_SE1730_BookingManagement.Services
{
    public interface IRoomService
    {
        int CountTotalRoomOfUser(string guestId);
        int CountRoomRemainOfUser(string guestId);
        int CountRoomByHomestayAndGuestId(long homestayId, string guestId);
    }
}
