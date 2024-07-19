using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Repositories
{
    public interface IRoomRepo
    {
        //CRUD
        Task<IEnumerable<Room?>> GetRoomsAsync();
        Task<Room?> GetRoomByIdAsync(long id);
        Task AddRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task DeleteRoomAsyncById(long id);

        Task<IEnumerable<Room?>> GetRoomListByHomestayIdAsync(long homestayId);

    }
}
