using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Services
{
    public interface IRoomService
    {
        Task<Room?> GetRoomByIdAsync(int roomId);

        Task<IEnumerable<Room?>> GetAllRoomsAsync();

        Task<IEnumerable<Room?>> GetRoomListByHomestayIdAsync(long homestayId);
        
        int CountTotalRoomOfUser(string guestId);
        int CountRoomRemainOfUser(string guestId);
        int CountRoomByHomestayAndGuestId(long homestayId, string guestId);
    }
}
