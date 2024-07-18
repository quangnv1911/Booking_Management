namespace Group5_SE1730_BookingManagement.Repositories
{
    public interface IRoomRepo
    {
        int CountTotalRoomOfUser(string guestId);
        int CountRoomRemainOfUser(string guestId);
        int CountRoomByHomestayAndGuestId(long homestayId, string guestId);
    }
}
