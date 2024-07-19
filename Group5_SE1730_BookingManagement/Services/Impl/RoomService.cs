using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Repositories;

namespace Group5_SE1730_BookingManagement.Services.Impl
{
    public class RoomService : IRoomService
    {
        private IRoomRepo _roomRepo;

        public RoomService(IRoomRepo roomRepo) {
            _roomRepo = roomRepo;
        }

        public async Task<IEnumerable<Room?>> GetAllRoomsAsync()
        {
            return await _roomRepo.GetRoomsAsync();
        }

        public async Task<Room?> GetRoomByIdAsync(int roomId)
        {
            return await _roomRepo.GetRoomByIdAsync(roomId);
        }

        public async Task<IEnumerable<Room?>> GetRoomListByHomestayIdAsync(long homestayId)
        {
            return await _roomRepo.GetRoomListByHomestayIdAsync(homestayId);
        }
        
        public int CountRoomByHomestayAndGuestId(long homestayId, string guestId)
        {
            return _roomRepo.CountRoomByHomestayAndGuestId(homestayId, guestId);
        }

        public int CountRoomRemainOfUser(string guestId)
        {
            return _roomRepo.CountRoomRemainOfUser(guestId);
        }

        public int CountTotalRoomOfUser(string guestId)
        {
            return _roomRepo.CountTotalRoomOfUser(guestId) ; ;
        }
    }
}
