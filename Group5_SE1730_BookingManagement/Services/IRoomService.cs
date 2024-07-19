using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Services
{
    public interface IRoomService
    {
        Task<Room?> GetRoomByIdAsync(int roomId);

        Task<IEnumerable<Room?>> GetAllRoomsAsync();

        Task<IEnumerable<Room?>> GetRoomListByHomestayIdAsync(long homestayId);
    }
}
